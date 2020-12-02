import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/services/notification.service';
import { ComicService } from '../../../../../services/comic.service';
import { Comic } from '../../../../../models/comic.model';
import { Observable, ReplaySubject, Subject, Subscription } from 'rxjs';
import { takeUntil, tap } from 'rxjs/operators';
import { Author } from 'src/app/models/author.model';
import { Genre } from 'src/app/models/genre.model';
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
  base64Image: string;
  comicImage: ComicImage;
  comic: Comic;
  _onDestroy = new Subject<void>();
  private subscriptions: Subscription[] = [];

  authors: Author[] = [];
  genres: Genre[] = [];

  authorsControl: FormControl = new FormControl();
  genresControl: FormControl = new FormControl();
  authorsSearchControl: FormControl = new FormControl();
  genresSearchControl: FormControl = new FormControl();

  /** Lista de categorias e autores filtradas pela pesquisa*/

  filteredAuthorsOptions$: ReplaySubject<Author[]> = new ReplaySubject<
    Author[]
  >(1);
  filteredGenresOptions$: ReplaySubject<Genre[]> = new ReplaySubject<Genre[]>(
    1
  );

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
    // this.data?.comicID ? 'Update' : 'Create';
    // if (this.data?.image) {
    //   this.imageDataUrl = 'data:image/jpg;base64,' + this.data?.image.base64;
    // }

    // carregando a lista inicial de categorias e autores do servidor
    this.getGenres();
    this.getAuthors();

    // escutando pela atualizações no campo de pesquisa de categorias e autores
    this.genresSearchControl.valueChanges
      .pipe(takeUntil(this._onDestroy))
      .subscribe(() => {
        this.filterGenres();
      });

    this.authorsSearchControl.valueChanges
      .pipe(takeUntil(this._onDestroy))
      .subscribe(() => {
        this.filterAuthors();
      });

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
      authors: this.authorsControl,
      genres: this.genresControl,
      image: new FormControl(this.data?.title || '', [Validators.required]),
    });

    this.subscribeToPreviewImageControl();
  }

  ngOnDestroy() {
    this._onDestroy.next();
    this._onDestroy.complete();
    this.subscriptions.forEach((c) => c.unsubscribe());
  }

  subscribeToPreviewImageControl(): void {
    this.form.controls['image'].valueChanges.subscribe((c) => {
      const file = c.files[0];
      this.readFileAsBinaryString(file).subscribe((comicImage: ComicImage) => {
        console.log(comicImage);

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

  getGenres() {
    this.subscriptions.push(
      this.genreService.getGenres().subscribe((c) => {
        this.genres = c.body;
        this.filteredGenresOptions$.next(this.genres);
      })
    );
  }

  getAuthors() {
    if (this.comic?.comicID) {
      this.subscriptions.push(
        this.comicService
          .GetAuthorsByComicID(this.comic.comicID)
          .subscribe((responseAuthors) => {
            this.authors = responseAuthors;
            this.authorsControl.setValue(
              responseAuthors.map((c) => c.authorID)
            );

            this.filteredAuthorsOptions$.next(this.authors);
          })
      );
    } else {
      this.subscriptions.push(
        this.authorService.getPaginatedAuthors().subscribe((c) => {
          this.authors = c.body;
          this.filteredAuthorsOptions$.next(this.authors);
        })
      );
    }
  }

  filterGenres() {
    if (!this.genres) {
      return;
    }

    // recuperando o termo de pesquisa

    let searchTerm = this.genresSearchControl.value;
    if (!searchTerm) {
      this.filteredGenresOptions$.next(this.genres);
      return;
    } else {
      searchTerm = searchTerm.toLowerCase();
    }

    // filtrando as categorias

    this.filteredGenresOptions$.next(
      this.genres.filter(
        (genre) => genre.description.toLowerCase().indexOf(searchTerm) > -1
      )
    );
  }

  filterAuthors() {
    if (!this.authors) {
      return;
    }
    // recuperando o termo de pesquisa
    let searchTerm = this.authorsSearchControl.value;
    if (!searchTerm) {
      this.filteredAuthorsOptions$.next(this.authors);
      return;
    } else {
      searchTerm = searchTerm.toLowerCase();
    }

    // filtrando os autores
    this.filteredAuthorsOptions$.next(
      this.authors.filter(
        (author) => author.name.toLowerCase().indexOf(searchTerm) > -1
      )
    );
  }

  // filterAuthors() {
  //   if (!this.authors) {
  //     return;
  //   }
  //   // get the search keyword
  //   const selectedItems = this.authorsControl.value || [];
  //   let search = this.authorsSearchControl.value;
  //   if (!search) {
  //     // this.filteredAuthorsOptions$.subscribe((c) => {
  //     //   this.selectedAuthors = [...this.selectedAuthors, ...c].filter(
  //     //     (d) => selectedItems && selectedItems.indexOf(d.authorID) !== -1
  //     //   );
  //     //   console.log('fim', this.selectedAuthors, selectedItems);

  //     //   this.filteredAuthorsOptions$.next([...this.selectedAuthors]);

  //     // });

  //     this.filteredAuthorsOptions$.next(this.authors.slice());

  //     return;
  //   } else {
  //     search = search.toLowerCase();
  //   }

  //   // filter the authors

  //   console.log('selectedItems', selectedItems);

  //   // this.filteredAuthorsOptions$.subscribe((c) => {
  //   //   this.selectedAuthors = c.filter(
  //   //     (d) => selectedItems && selectedItems.indexOf(d.authorID) !== -1
  //   //   );
  //   //   console.log('filter:', this.selectedAuthors);
  //   // });

  //   const result = this.authors.filter(
  //     (author) => author.name.toLowerCase().indexOf(search) > -1
  //   );

  //   // this.selectedAuthors = [
  //   //   // ...this.selectedAuthors,
  //   //   ...result.filter(
  //   //     (c) =>
  //   //       this.selectedAuthors &&
  //   //       !this.selectedAuthors.find((d) => d.authorID === c.authorID)
  //   //   ),
  //   // ];
  //   console.log('next', this.selectedAuthors);

  //   this.filteredAuthorsOptions$.next([...result]);
  //   // this.filteredAuthorsOptions$.next([...this.selectedAuthors]);
  // }
}
