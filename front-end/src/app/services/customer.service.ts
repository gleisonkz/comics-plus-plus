import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthorizationService } from './authorization.service';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  constructor(
    private http: HttpClient,
    private jwtHelperService: JwtHelperService,
    private authorizationService: AuthorizationService
  ) {}

  // getCustomerAddress(customerID: number): Observable<Comic> {
  //   return this.http.get<Comic>(`${environment.apiURL}/comic/${comicID}`);
  // }

  getCustomerID(): number {
    const decodedToken = this.authorizationService.getDecodeToken();
    const customerID = decodedToken && +decodedToken['customerID'];
    return customerID;
  }
}
