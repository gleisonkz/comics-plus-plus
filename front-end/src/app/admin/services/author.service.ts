import { Author } from '@admin/models';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GenericBaseService } from '@core/services';

@Injectable()
export class AuthorService extends GenericBaseService<Author> {
  constructor(protected http: HttpClient) {
    super(http);
    this.endpoint = '/author';
  }

  getAuthorsByName(name: string) {
    return this.http.get<Author[]>(`${this.endpoint}/${name}`);
  }

  getPaginatedAuthors = this.getPaginatedEntities;
  postAuthor = this.postEntity;
  putAuthor = this.putEntity;
  deleteAuthor = this.deleteEntity;
}
