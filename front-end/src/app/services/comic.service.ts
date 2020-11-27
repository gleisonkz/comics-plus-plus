import { ErrorHandler, Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Comic } from '../models/comic.model';
import { Observable, of } from 'rxjs';
import { COMICS } from '../mock/comics.mock';
import { Filter } from '../models/filter.model';
import { environment } from 'src/environments/environment';
import { catchError, delay } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class ComicService {
  constructor(private http: HttpClient) {}

  getComics(): Observable<Comic[]> {
    return of(COMICS);
  }

  getComics2(comicFilter: Filter): Observable<HttpResponse<Comic[]>> {
    return this.http
      .get<Comic[]>(`${environment.apiURL}/comic`, {
        observe: 'response',
        responseType: 'json',
        params: comicFilter,
      })
      .pipe(delay(200));
  }

  getComicByID(comicID: number): Observable<Comic> {
    const foundComic = COMICS.find((c) => c.comicID === comicID);
    return of(foundComic);
    // return this.http
    //   .get<Comic>(`${environment.meatApiUrl}/livros/${restaurantID}`)
    //   .pipe(catchError(ErrorHandler.handleError));
  }

  postComic(comic: Comic): Observable<Comic> {
    return this.http.post<Comic>(`${environment.apiURL}/comic`, comic);
  }

  putComic(comicID: number, comic: Comic): Observable<Comic> {
    return this.http.put<Comic>(
      `${environment.apiURL}/comic/${comicID}`,
      comic
    );
  }
  deleteComic(comicID: number): Observable<Comic> {
    return this.http.delete<Comic>(`${environment.apiURL}/comic/${comicID}`);
  }
}
