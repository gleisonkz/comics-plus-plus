import { Author } from '@admin/models';
import { AuthorResource } from '@admin/models/author-resource.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GenericBaseService } from '@core/services';
import { AuthorListItem } from '../models/author-list.model';

@Injectable()
export class AuthorService extends GenericBaseService<
  AuthorResource,
  AuthorListItem,
  Author
> {
  constructor(protected http: HttpClient) {
    super(http);
    this.endpoint = '/author';
  }

  getAuthorsByName(name: string) {
    return this.http.get<Author[]>(`${this.endpoint}/${name}`);
  }

  getPaginatedAuthors = this.getPaginatedEntities;
  getAuthorByID = this.getEntity;
  postAuthor = this.postEntity;
  putAuthor = this.putEntity;
  deleteAuthor = this.deleteEntity;
}
