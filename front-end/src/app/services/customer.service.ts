import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  constructor(private http: HttpClient) {}

  // getCustomerAddress(customerID: number): Observable<Comic> {
  //   return this.http.get<Comic>(`${environment.apiURL}/comic/${comicID}`);
  // }
}
