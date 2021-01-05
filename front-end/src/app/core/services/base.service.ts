import { Filter } from '@admin/models';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export abstract class BaseService {
  constructor() {}

  private _endpoint = '';

  protected set endpoint(endpoint: string) {
    this._endpoint = `${environment.apiURL}${endpoint}`;
  }

  protected get endpoint(): string {
    return this._endpoint;
  }

  protected getPaginatedData<T>(
    http: HttpClient,
    filter?: Filter,
    segment?: string
  ): Observable<HttpResponse<T[]>> {
    const endpoints = [this.endpoint, segment, 'paginator']
      .filter((endpoint) => !!endpoint)
      .join('/');

    return http.get<T[]>(endpoints, {
      observe: 'response',
      responseType: 'json',
      params: filter
    });
  }
}

export abstract class GenericBaseService<T> extends BaseService {
  constructor(protected http: HttpClient) {
    super();
  }

  getPaginatedEntities(filter: Filter): Observable<HttpResponse<T[]>> {
    return this.getPaginatedData(this.http, filter);
  }

  postEntity(obj: T): Observable<T> {
    return this.http.post<T>(this.endpoint, obj);
  }

  putEntity(id: number, author: T): Observable<T> {
    return this.http.put<T>(`${this.endpoint}/${id}`, author);
  }
  deleteEntity(id: number): Observable<T> {
    return this.http.delete<T>(`${this.endpoint}/${id}`);
  }
}
