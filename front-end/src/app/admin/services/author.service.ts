import { Author, Filter } from '@admin/models';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from '@core/services';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';

@Injectable()
export class AuthorService extends BaseService {
  constructor(protected http: HttpClient) {
    super(http);
  }

  getPaginatedAuthors(comicFilter: Filter): Observable<HttpResponse<Author[]>> {
    return this.getPaginatedData('author', comicFilter);
  }

  getAuthorsByName(name: string) {
    return this.http.get<Author[]>(`${environment.apiURL}/author/${name}`);
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
