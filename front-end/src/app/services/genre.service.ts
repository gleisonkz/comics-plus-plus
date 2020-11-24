import { Injectable, OnInit } from '@angular/core';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { Genre } from '../modules/admin/components/genre-crud/genre-crud.component';
import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map, tap, delay } from 'rxjs/operators';

@Injectable()
export class GenreService {
  constructor(private http: HttpClient) {}

  getGenres(filter = '', sortOrder = 'asc', pageNumber = 1, pageSize = 2): any {
    return this.http
      .get<Genre[]>(`${environment.apiURL}/genre`, {
        observe: 'response',
        responseType: 'json',
        params: new HttpParams()
          // .set('filter', filter)
          // .set('sortOrder', sortOrder)
          .set('pageNumber', pageNumber.toString())
          .set('pageSize', pageSize.toString()),
      })
      .pipe(delay(200));
  }

  postGenre(genre: Genre): Observable<Genre> {
    console.log('service:', genre);

    return this.http.post<Genre>(`${environment.apiURL}/genre`, genre);
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
