import { Injectable, OnInit } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Genre } from '../modules/admin/components/genre-crud/genre-crud.component';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable()
export class GenreService {
  constructor(private http: HttpClient) {}

  getGenres(
    filter = '',
    sortOrder = 'asc',
    pageNumber = 0,
    pageSize = 3
  ): Observable<Genre[]> {
    return this.http.get<Genre[]>(`${environment.apiURL}/genre`, {
      params: new HttpParams()
        .set('filter', filter)
        .set('sortOrder', sortOrder)
        .set('pageNumber', pageNumber.toString())
        .set('pageSize', pageSize.toString()),
    });
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
