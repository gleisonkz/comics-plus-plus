import { CollectionViewer, DataSource } from '@angular/cdk/collections';
import { Observable, BehaviorSubject, of } from 'rxjs';
import { catchError, finalize } from 'rxjs/operators';
import { Genre } from './genre-crud.component';
import { GenreService } from '../../../../services/genre.service';

export class GenresDataSource implements DataSource<Genre> {
  private genresSubject = new BehaviorSubject<Genre[]>([]);

  private loadingGenres = new BehaviorSubject<boolean>(false);

  public loading$ = this.loadingGenres.asObservable();

  constructor(private genreService: GenreService) {}

  loadGenres(
    filter: string,
    sortDirection: string,
    pageIndex: number,
    pageSize: number
  ) {
    this.loadingGenres.next(true);

    this.genreService
      .getGenres(filter, sortDirection, pageIndex, pageSize)
      .pipe(
        catchError(() => of([])),
        finalize(() => this.loadingGenres.next(false))
      )
      .subscribe((genres) => this.genresSubject.next(genres));
  }

  connect(collectionViewer: CollectionViewer): Observable<Genre[]> {
    console.log('Connecting data source');
    return this.genresSubject.asObservable();
  }

  disconnect(collectionViewer: CollectionViewer): void {
    this.genresSubject.complete();
    this.loadingGenres.complete();
  }
}
