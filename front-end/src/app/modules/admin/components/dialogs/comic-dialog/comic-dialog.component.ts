import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/services/notification.service';
import { ComicService } from '../../../../../services/comic.service';
import { Comic } from '../../../../../models/comic.model';
import { Observable, Subject, Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';

import { GenreService } from '../../../../../services/genre.service';
import { AuthorService } from '../../../../../services/author.service';
import { ComicImage } from '../../../../../models/comic-image.model';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';

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
      image: new FormControl(this.data?.image?.name || '', [
        Validators.required,
      ]),
    });

    this.subscribeToPreviewImageControl();
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
      const file = c.files[0];
      this.readFileAsBinaryString(file).subscribe((comicImage: ComicImage) => {
        this.imageDataUrl = this.domSanitizer.bypassSecurityTrustUrl(
          `data:image/${comicImage.extension};base64,` + comicImage.base64
        );
        this.comicImage = comicImage;
      });
    });
  }

  loadComicImage(comicID: number) {
    this.comicService.getComicImageByComicID(comicID).subscribe((c) => {
      this.imageDataUrl = this.domSanitizer.bypassSecurityTrustUrl(
        `data:image/${c.extension};base64,` + c.base64
      );
    });
  }

  save() {
    const comic: Comic = this.form.value;
    comic.image = this.comicImage;

    const saveObj: { operation: string; author$: Observable<Comic> } =
      this.data?.comicID > 0
        ? {
            operation: 'atualizado',
            author$: this.comicService.putComic(
              this.data.comicID,
              this.form.value
            ),
          }
        : {
            operation: 'criado',
            author$: this.comicService.postComic(comic),
          };

    saveObj.author$
      .pipe(
        tap(() =>
          this.notificationService.showMessage(
            `O registro foi ${saveObj.operation} com sucesso!`
          )
        )
      )
      .subscribe((author: Comic) => this.dialogRef.close(author));
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
