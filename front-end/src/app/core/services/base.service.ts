import { Filter } from '@admin/models';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export abstract class BaseService {
  constructor(protected http: HttpClient) {}

  getPaginatedData<T>(
    endpoint: string,
    filter?: Filter
  ): Observable<HttpResponse<T[]>> {
    return this.http.get<T[]>(`${environment.apiURL}/${endpoint}/paginator`, {
      observe: 'response',
      responseType: 'json',
      params: filter
    });
  }
}
