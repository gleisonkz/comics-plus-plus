import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root',
})
export class AuthorizationService {
  constructor(private jwtHelperService: JwtHelperService) {}

  getUserRoles(): any {
    const decodeToken = this.getDecodeToken();
    const roles = decodeToken && decodeToken['role'];
    return roles;
  }

  isLoggedIn(): boolean {
    const decodeToken = this.getDecodeToken();
    if (!decodeToken) {
      return false;
    }
    return true;
  }

  getDecodeToken() {
    // get token from local storage or state management
    const token = localStorage.getItem('token');

    // decode token to read the payload details
    const decodeToken = this.jwtHelperService.decodeToken(token);

    return decodeToken;
  }

  isAuthorized(allowedRoles: string[]): boolean {
    // check if the list of allowed roles is empty, if empty, authorize the user to access the page
    if (allowedRoles == null || allowedRoles.length === 0) {
      return true;
    }

    const decodeToken = this.getDecodeToken();

    // check if it was decoded successfully, if not the token is not valid, deny access
    if (!decodeToken) {
      console.log('Invalid token');
      return false;
    }

    // check if the user roles is in the list of allowed roles, return true if allowed and false if not allowed
    return allowedRoles.includes(decodeToken['role']);
  }
}
