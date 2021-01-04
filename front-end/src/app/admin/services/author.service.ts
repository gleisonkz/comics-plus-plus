import { Author, Filter } from '@admin/models';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from '@core/services';
import { Observable } from 'rxjs';

@Injectable()
export class AuthorService extends BaseService {
  constructor(protected http: HttpClient) {
    super();
    this.endpoint = '/author';
  }

  getPaginatedAuthors(comicFilter: Filter): Observable<HttpResponse<Author[]>> {
    return this.getPaginatedData(this.http, comicFilter);
  }

  getAuthorsByName(name: string) {
    return this.http.get<Author[]>(`${this.endpoint}/${name}`);
  }

  postAuthor(author: Author): Observable<Author> {
    return this.http.post<Author>(this.endpoint, author);
  }

  putAuthor(authorID: number, author: Author): Observable<Author> {
    return this.http.put<Author>(`${this.endpoint}/${authorID}`, author);
  }
  deleteAuthor(authorID: number): Observable<Author> {
    return this.http.delete<Author>(`${this.endpoint}/${authorID}`);
  }
}
