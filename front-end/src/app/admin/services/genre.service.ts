import { Filter, Genre } from '@admin/models';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from '@core/services';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';

@Injectable()
export class GenreService extends BaseService {
  constructor(protected http: HttpClient) {
    super(http);
  }

  getPaginatedGenres(comicFilter: Filter): Observable<HttpResponse<Genre[]>> {
    return this.getPaginatedData('genre', comicFilter);
  }

  getGenresByName(description: string) {
    return this.http.get<Genre[]>(`${environment.apiURL}/genre/${description}`);
  }

  postGenre(genre: Genre): Observable<Genre> {
    return this.http.post<Genre>(`${environment.apiURL}/genre`, genre);
  }

  putGenre(genreID: number, genre: Genre): Observable<Genre> {
    return this.http.put<Genre>(
      `${environment.apiURL}/genre/${genreID}`,
      genre
    );
  }
  deleteGenre(genreID: number): Observable<Genre> {
    return this.http.delete<Genre>(`${environment.apiURL}/genre/${genreID}`);
  }

  deleteGenreRelationships(genreID: number): Observable<Genre> {
    return this.http.delete<Genre>(
      `${environment.apiURL}/genre/${genreID}/relationships`
    );
  }
}
