import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { delay } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Author } from '../models/author.model';
import { Filter } from '../models/filter.model';

@Injectable({
  providedIn: 'root',
})
export class AuthorService {
  constructor(private http: HttpClient) {}

  getAuthors(authorFilter: Filter): Observable<HttpResponse<Author[]>> {
    return this.http
      .get<Author[]>(`${environment.apiURL}/author`, {
        observe: 'response',
        responseType: 'json',
        params: authorFilter,
      })
      .pipe(delay(200));
  }

  postAuthor(author: Author): Observable<Author> {
    return this.http.post<Author>(`${environment.apiURL}/author`, author);
  }

  putAuthor(authorID: number, author: Author): Observable<Author> {
    return this.http.put<Author>(
      `${environment.apiURL}/author/${authorID}`,
      author
    );
  }
  deleteAuthor(authorID: number): Observable<Author> {
    return this.http.delete<Author>(`${environment.apiURL}/author/${authorID}`);
  }
}