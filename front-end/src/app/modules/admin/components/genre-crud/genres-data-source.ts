import { CollectionViewer, DataSource } from '@angular/cdk/collections';
import { Observable, BehaviorSubject, of } from 'rxjs';
import { debounceTime, finalize } from 'rxjs/operators';
import { Genre } from 'src/app/models/genre.model';
import { GenreService } from '../../../../services/genre.service';
import { Filter } from '../../../../models/filter.model';
import { HttpResponse } from '@angular/common/http';

export class GenresDataSource implements DataSource<Genre> {
  private genresSubject = new BehaviorSubject<Genre[]>([]);

  private loadingGenres = new BehaviorSubject<boolean>(false);

  public loading$ = this.loadingGenres.asObservable().pipe(debounceTime(200));

  constructor(private genreService: GenreService) {}

  loadGenres(genreFilter: Filter) {
    return new Observable<number>((publisher) => {
      this.loadingGenres.next(true);

      this.genreService
        .getGenres(genreFilter)
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
    return this.genresSubject.asObservable();
  }

  disconnect(collectionViewer: CollectionViewer): void {
    this.genresSubject.complete();
    this.loadingGenres.complete();
  }
}
