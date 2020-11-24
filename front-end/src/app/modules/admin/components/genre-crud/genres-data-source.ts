import { CollectionViewer, DataSource } from '@angular/cdk/collections';
import { Observable, BehaviorSubject, of } from 'rxjs';
import {
  catchError,
  debounceTime,
  delay,
  finalize,
  switchMap,
} from 'rxjs/operators';
import { Genre } from './genre-crud.component';
import { GenreService } from '../../../../services/genre.service';
import { JsonPipe } from '@angular/common';

export class GenresDataSource implements DataSource<Genre> {
  private genresSubject = new BehaviorSubject<Genre[]>([]);

  private loadingGenres = new BehaviorSubject<boolean>(false);

  public loading$ = this.loadingGenres.asObservable().pipe(debounceTime(200));

  constructor(private genreService: GenreService) {}

  loadGenres(
    filter: string,
    sortDirection: string,
    pageIndex: number,
    pageSize: number
  ) {
    return new Observable<number>((publisher) => {
      console.log('init');
      this.loadingGenres.next(true);

      this.genreService
        .getGenres(filter, sortDirection, pageIndex, pageSize)
        .pipe(
          // catchError(() => of([])),
          finalize(() => this.loadingGenres.next(false))
        )
        .subscribe((genres) => {
          const pagination = JSON.parse(genres.headers.get('x-pagination'));
          publisher.next(pagination);

          this.loadingGenres.next(false);
          return this.genresSubject.next(genres.body);
        });
    });
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
