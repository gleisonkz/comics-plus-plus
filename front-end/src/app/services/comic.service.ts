import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Comic } from '../models/comic.model';
import { Observable, of } from 'rxjs';
import { COMICS } from '../mock/comics.mock';

@Injectable({
  providedIn: 'root',
})
export class ComicService {
  constructor(private http: HttpClient) {}

  getComics(): Observable<Comic[]> {
    // return this.http
    //   .get<Comic[]>(`${environment.comicApiURL}/livros`)
    //   .pipe(catchError(ErrorHandler.handleError));
    return of(COMICS);
  }

  getComicByID(comicID: number): Observable<Comic> {
    const foundComic = COMICS.find((c) => c.id === comicID);
    return of(foundComic);
    // return this.http
    //   .get<Comic>(`${environment.meatApiUrl}/livros/${restaurantID}`)
    //   .pipe(catchError(ErrorHandler.handleError));
  }
}