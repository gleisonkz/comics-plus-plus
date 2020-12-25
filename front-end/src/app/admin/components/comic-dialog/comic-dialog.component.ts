import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { FileInput } from 'ngx-material-file-input';
import { Observable, Subject, Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ComicImage } from 'src/app/models/comic-image.model';
import { Comic } from 'src/app/modules/admin/models/comic.model';
import { AuthorService } from 'src/app/services/author.service';
import { ComicService } from 'src/app/services/comic.service';
import { GenreService } from 'src/app/services/genre.service';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
  templateUrl: './comic-dialog.component.html',
  styleUrls: ['./comic-dialog.component.scss'],
})
export class ComicDialogComponent implements OnInit {
  form: FormGroup;
  imageDataUrl: string | ArrayBuffer | SafeUrl;
  comicImage: ComicImage;
  comic: Comic;
  _onDestroy = new Subject<void>();
  private subscriptions: Subscription[] = [];

  constructor(
    private dialogRef: MatDialogRef<ComicDialogComponent>,
    private comicService: ComicService,
    private notificationService: NotificationService,
    private genreService: GenreService,
    private authorService: AuthorService,
    private domSanitizer: DomSanitizer,
    @Inject(MAT_DIALOG_DATA) private data: Comic
  ) {
    this.comic = data;
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      comicID: new FormControl(this.data?.comicID || 0),
      title: new FormControl(this.data?.title || '', [Validators.required]),
      description: new FormControl(this.data?.description || '', [
        Validators.required,
      ]),
      price: new FormControl(this.data?.price || '', [Validators.required]),
      year: new FormControl(this.data?.year || '', [
        Validators.required,
        Validators.minLength(4),
      ]),
      pages: new FormControl(this.data?.pages || '', [Validators.required]),
      authors: new FormControl([], [Validators.required]),
      genres: new FormControl([], [Validators.required]),
      image: new FormControl(this.data?.image || '', [Validators.required]),
    });

    this.subscribeToPreviewImageControl();
    this.loadPreviewImage();
  }

  ngOnDestroy() {
    this._onDestroy.next();
    this._onDestroy.complete();
    this.subscriptions.forEach((c) => c.unsubscribe());
  }

  getAuthorByNameCallback(searchTerm: string) {
    return this.authorService.getAuthorsByName(searchTerm);
  }

  getAuthorsByComicIDCallback() {
    return this.comicService.GetAuthorsByComicID(this.comic?.comicID);
  }

  getGenresByNameCallback(searchTerm: string) {
    return this.genreService.getGenresByName(searchTerm);
  }

  getGenresByComicIDCallback() {
    return this.comicService.GetGenresByComicID(this.comic?.comicID);
  }

  subscribeToPreviewImageControl(): void {
    this.form.controls['image'].valueChanges.subscribe((c) => {
      const file: File = c.files[0];

      this.readFileAsBinaryString(file).subscribe((comicImage: ComicImage) => {
        this.imageDataUrl = this.domSanitizer.bypassSecurityTrustUrl(
          `data:image/${comicImage.extension};base64,` + comicImage.base64
        );
        this.comicImage = comicImage;
      });
    });
  }

  loadPreviewImage() {
    if (this.comic?.comicID > 0) {
      this.comicService
        .getComicImageByComicID(this.comic.comicID)
        .subscribe((image) => {
          const base64toBlob = (base64, type = 'application/octet-stream') =>
            fetch(`data:${type};base64,${base64}`).then((res) => res.blob());

          base64toBlob(image.base64, 'image').then((c) => {
            const file = new File([c], `${image.name}.${image.extension}`, {
              type: `image/${image.extension}`,
            });
            const fileInput = new FileInput([file]);
            this.form.controls.image.setValue(fileInput);
          });
        });
    }
  }

  save() {
    const comic: Comic = this.form.value;
    comic.image = this.comicImage;

    const saveObj: { operation: string; comic$: Observable<Comic> } =
      this.data?.comicID > 0
        ? {
            operation: 'atualizado',
            comic$: this.comicService.putComic(
              this.data.comicID,
              this.form.value
            ),
          }
        : {
            operation: 'criado',
            comic$: this.comicService.postComic(comic),
          };

    saveObj.comic$
      .pipe(
        tap(() =>
          this.notificationService.showMessage(
            `O registro foi ${saveObj.operation} com sucesso!`
          )
        )
      )
      .subscribe(() => this.dialogRef.close(true));
  }

  close() {
    this.dialogRef.close();
  }

  readFileAsBinaryString(file: File): Observable<ComicImage> {
    const temporaryFileReader = new FileReader();
    const [fileName, fileExtension] = file.name.split('.');

    return new Observable<ComicImage>((publisher) => {
      temporaryFileReader.onload = () => {
        const binaryString = temporaryFileReader.result as string;
        const base64 = btoa(binaryString);
        const comicImage: ComicImage = {
          base64: base64,
          extension: fileExtension,
          name: fileName,
        };
        publisher.next(comicImage);
      };

      temporaryFileReader.onerror = () => {
        temporaryFileReader.abort();
        publisher.error('Problem parsing with file.');
      };

      temporaryFileReader.readAsBinaryString(file);
    });
  }
}
