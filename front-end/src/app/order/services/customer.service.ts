import { Injectable } from '@angular/core';
import { AuthorizationService } from '@core/services';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  constructor(private authorizationService: AuthorizationService) {}

  getCustomerID(): number {
    const decodedToken = this.authorizationService.getDecodeToken();
    const customerID = decodedToken && +decodedToken['customerID'];
    return customerID;
  }
}
