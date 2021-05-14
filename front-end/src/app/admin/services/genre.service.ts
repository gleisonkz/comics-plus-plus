import { Genre, GenreListItem, GenreResource } from '@admin/models';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GenericBaseService } from '@core/services';
import { Observable } from 'rxjs';

@Injectable()
export class GenreService extends GenericBaseService<GenreResource, GenreListItem, Genre> {
  constructor(protected http: HttpClient) {
    super(http);
    this.endpoint = '/genre';
  }

  getPaginatedGenres = this.getPaginatedEntities;
  postGenre = this.postEntity;
  putGenre = this.putEntity;
  deleteGenre = this.deleteEntity;

  getGenresByName(description: string) {
    return this.http.get<Genre[]>(`${this.endpoint}/${description}`);
  }

  deleteGenreRelationships(genreID: number): Observable<Genre> {
    return this.http.delete<Genre>(`${this.endpoint}/${genreID}/relationships`);
  }
}
