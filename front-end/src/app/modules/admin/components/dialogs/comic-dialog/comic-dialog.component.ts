import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/services/notification.service';
import { ComicService } from '../../../../../services/comic.service';
import { Comic } from '../../../../../models/comic.model';
import { Observable, ReplaySubject, Subject, Subscription } from 'rxjs';
import { filter, takeUntil, tap } from 'rxjs/operators';
import { Author } from 'src/app/models/author.model';
import { MatSelect } from '@angular/material/select';
import { Genre } from 'src/app/models/genre.model';
import { GenreService } from '../../../../../services/genre.service';

@Component({
  templateUrl: './comic-dialog.component.html',
  styleUrls: ['./comic-dialog.component.scss'],
})
export class ComicDialogComponent implements OnInit {
  form: FormGroup;
  imagePreview;

  authors: Author[] = [
    {
      authorID: 1,
      name: 'Roger',
    },
    {
      authorID: 2,
      name: 'Fred',
    },
    {
      authorID: 3,
      name: 'John',
    },
    {
      authorID: 4,
      name: 'Richard',
    },
    {
      authorID: 6,
      name: 'Stan Lee',
    },
  ];

  genres: Genre[] = [];

  public authorsControl: FormControl = new FormControl();
  public authorsSearchControl: FormControl = new FormControl();
  public selectedAuthors: Author[] = [];
  public filteredAuthorsOptions$: ReplaySubject<Author[]> = new ReplaySubject<
    Author[]
  >(1);

  protected _onDestroy = new Subject<void>();
  private subscriptions: Subscription[] = [];

  @ViewChild('multiSelect', { static: true }) multiSelect: MatSelect;

  /** control for the selected bank for multi-selection */
  public genreCtrl: FormControl = new FormControl();

  /** control for the MatSelect filter keyword multi-selection */
  public genreSearchCtrl: FormControl = new FormControl();

  /** Lista de categorias filtradas pela pesquisa*/
  public filteredGenresOptions$: ReplaySubject<Genre[]> = new ReplaySubject<
    Genre[]
  >(1);

  constructor(
    private dialogRef: MatDialogRef<ComicDialogComponent>,
    private comicService: ComicService,
    private notificationService: NotificationService,
    private genreService: GenreService,

    @Inject(MAT_DIALOG_DATA) private data: Comic
  ) {}

  ngOnInit(): void {
    // carregando a lista inicial de categorias do servidor
    this.getGenres();

    // escutando pela atualizações no campo de pesquisa
    this.genreSearchCtrl.valueChanges
      .pipe(takeUntil(this._onDestroy))
      .subscribe(() => {
        this.filterGenres();
      });

    this.form = new FormGroup({
      comicID: new FormControl(this.data?.comicID || 0),
      title: new FormControl(this.data?.title || '', [
        Validators.required,
        Validators.minLength(3),
      ]),
      description: new FormControl(this.data?.description || '', [
        Validators.required,
        Validators.minLength(3),
      ]),
      price: new FormControl(this.data?.price || '', [
        Validators.required,
        Validators.minLength(3),
      ]),
      year: new FormControl(this.data?.year || '', [
        Validators.required,
        Validators.minLength(3),
      ]),
      pages: new FormControl(this.data?.pages || '', [
        Validators.required,
        Validators.minLength(3),
      ]),
      authors: this.authorsControl,
      genres: this.genreCtrl,
      image: new FormControl(this.data?.title || '', [
        Validators.required,
        Validators.minLength(3),
      ]),
    });

    this.getPreviewImage();

    // listen for search field value changes
    this.subscriptions.push(
      this.authorsSearchControl.valueChanges
        .pipe(
          // tap((c) => this.filteredAuthorsMulti$.next(this.selectedAuthors)),
          filter((c) => c.toString().length > 0),
          takeUntil(this._onDestroy)
        )
        .subscribe(() => {
          this.filterAuthors();
        })
    );
  }

  ngOnDestroy() {
    this._onDestroy.next();
    this._onDestroy.complete();
    this.subscriptions.forEach((c) => c.unsubscribe());
  }

  getPreviewImage(): void {
    this.form.controls['image'].valueChanges.subscribe((c) => {
      const file = c.files[0];
      this.readFile(file).subscribe((c) => (this.imagePreview = c));
    });
  }

  save() {
    console.log(this.form.value);
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
            author$: this.comicService.postComic(this.form.value),
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

  readFile(file: File): Observable<string | ArrayBuffer> {
    const temporaryFileReader = new FileReader();

    return new Observable<string | ArrayBuffer>((publisher) => {
      temporaryFileReader.onload = () => {
        publisher.next(temporaryFileReader.result);
      };

      temporaryFileReader.onerror = () => {
        temporaryFileReader.abort();
        publisher.error('Problem parsing with file.');
      };

      temporaryFileReader.readAsDataURL(file);
    });
  }

  filterAuthors() {
    if (!this.authors) {
      return;
    }
    // get the search keyword
    const selectedItems = this.authorsControl.value || [];
    let search = this.authorsSearchControl.value;
    if (!search) {
      // this.filteredAuthorsOptions$.subscribe((c) => {
      //   this.selectedAuthors = [...this.selectedAuthors, ...c].filter(
      //     (d) => selectedItems && selectedItems.indexOf(d.authorID) !== -1
      //   );
      //   console.log('fim', this.selectedAuthors, selectedItems);

      //   this.filteredAuthorsOptions$.next([...this.selectedAuthors]);

      // });

      this.filteredAuthorsOptions$.next(this.authors.slice());

      return;
    } else {
      search = search.toLowerCase();
    }

    // filter the authors

    console.log('selectedItems', selectedItems);

    // this.filteredAuthorsOptions$.subscribe((c) => {
    //   this.selectedAuthors = c.filter(
    //     (d) => selectedItems && selectedItems.indexOf(d.authorID) !== -1
    //   );
    //   console.log('filter:', this.selectedAuthors);
    // });

    const result = this.authors.filter(
      (author) => author.name.toLowerCase().indexOf(search) > -1
    );

    // this.selectedAuthors = [
    //   // ...this.selectedAuthors,
    //   ...result.filter(
    //     (c) =>
    //       this.selectedAuthors &&
    //       !this.selectedAuthors.find((d) => d.authorID === c.authorID)
    //   ),
    // ];
    console.log('next', this.selectedAuthors);

    this.filteredAuthorsOptions$.next([...result]);
    // this.filteredAuthorsOptions$.next([...this.selectedAuthors]);
  }

  getGenres() {
    this.genreService.getGenres().subscribe((c) => {
      this.genres = c.body;
      this.filteredGenresOptions$.next(this.genres);
    });
  }

  filterGenres() {
    if (!this.genres) {
      return;
    }

    // recuperando o termo de pesquisa

    let searchTerm = this.genreSearchCtrl.value;
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
}
