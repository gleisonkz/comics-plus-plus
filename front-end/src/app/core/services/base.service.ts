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

export abstract class GenericBaseService<
  TResource,
  TListItem,
  TEntity
> extends BaseService {
  constructor(protected http: HttpClient) {
    super();
  }

  getPaginatedEntities(filter: Filter): Observable<HttpResponse<TListItem[]>> {
    return this.getPaginatedData(this.http, filter);
  }

  postEntity(obj: TResource): Observable<any> {
    return this.http.post<TResource>(this.endpoint, obj);
  }

  putEntity(id: number, obj: TResource): Observable<any> {
    return this.http.put<TResource>(`${this.endpoint}/${id}`, obj);
  }

  getEntity(id: number): Observable<TEntity> {
    console.log(id);
    console.log(`${this.endpoint}/${id}`);

    return this.http.get<TEntity>(`${this.endpoint}/${id}`);
  }

  deleteEntity(id: number): Observable<TEntity> {
    return this.http.delete<TEntity>(`${this.endpoint}/${id}`);
  }
}
