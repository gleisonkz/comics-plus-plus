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
