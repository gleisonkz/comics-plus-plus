import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { Observable } from 'rxjs';
import { delay } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { Genre } from '../models/genre.model';
import { Filter } from '../models/filter.model';

@Injectable()
export class GenreService {
  constructor(private http: HttpClient) {}

  getGenres(genreFilter: Filter): any {
    const dest = Object.entries({
      ...genreFilter,
    }).reduce((acc, cur) => {
      acc[cur[0]] = cur[1];
      return acc;
    }, {});
    console.log('as', dest);

    return this.http
      .get<Genre[]>(`${environment.apiURL}/genre`, {
        observe: 'response',
        responseType: 'json',
        // params: Object.assign({},genreFilter.model)

        params: Object.entries({
          ...genreFilter,
        }).reduce((acc, cur) => {
          acc[cur[0]] = cur[1];
          return acc;
        }, {}),

        // params: new HttpParams()
        //   .set('genreID', genrePaginator.model?.genreID )
        //   .set('description', genrePaginator.model?.description || '')
        //   .set('pageNumber', genrePaginator.pageNumber.toString())
        //   .set('pageSize', genrePaginator.pageSize.toString()),
      })
      .pipe(delay(200));
  }

  postGenre(genre: Genre): Observable<Genre> {
    return this.http.post<Genre>(`${environment.apiURL}/genre`, genre);
  }

  putGenre(genreID: number, genre: Genre): Observable<Genre> {
    return this.http.put<Genre>(
      `${environment.apiURL}/genre/${genreID}`,
      genre
    );
  }
  deleteGenre(genreID: number): Observable<Genre> {
    return this.http.delete<Genre>(`${environment.apiURL}/genre/${genreID}`);
  }

  // get hasItems(): boolean {
  //   return !!this.itemsSource$.value.length;
  // }

  // get totalItems(): number {
  //   return this.itemsSource$.value.length;
  // }

  // public saveItem(item: Genre) {
  //   const foundItem = this.itemsSource$.value.find(
  //     (c) => c.genreID === item.genreID
  //   );

  //   const expectations = [
  //     {
  //       expect: () => foundItem !== undefined,
  //       action: () => {
  //         foundItem.name = item.name;
  //         this.itemsSource$.next(this.itemsSource$.value);
  //       },
  //     },
  //     {
  //       expect: () => true,
  //       action: () =>
  //         this.itemsSource$.next([...this.itemsSource$.value, item]),
  //     },
  //   ];
  //   const currentExpect = expectations.find((c) => c.expect());
  //   currentExpect.action();
  // }
}
