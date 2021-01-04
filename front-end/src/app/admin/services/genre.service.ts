import { Filter, Genre } from '@admin/models';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from '@core/services';
import { Observable } from 'rxjs';

@Injectable()
export class GenreService extends BaseService {
  constructor(protected http: HttpClient) {
    super();
    this.endpoint = '/genre';
  }

  getPaginatedGenres(comicFilter: Filter): Observable<HttpResponse<Genre[]>> {
    return this.getPaginatedData(this.http, comicFilter);
  }

  getGenresByName(description: string) {
    return this.http.get<Genre[]>(`${this.endpoint}/${description}`);
  }

  postGenre(genre: Genre): Observable<Genre> {
    return this.http.post<Genre>(this.endpoint, genre);
  }

  putGenre(genreID: number, genre: Genre): Observable<Genre> {
    return this.http.put<Genre>(`${this.endpoint}/${genreID}`, genre);
  }

  deleteGenre(genreID: number): Observable<Genre> {
    return this.http.delete<Genre>(`${this.endpoint}/${genreID}`);
  }

  deleteGenreRelationships(genreID: number): Observable<Genre> {
    return this.http.delete<Genre>(`${this.endpoint}/${genreID}/relationships`);
  }
}
