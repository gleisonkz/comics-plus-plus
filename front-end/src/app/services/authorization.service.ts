import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Role } from '../enums/role.enum';
import { NotificationService } from '../modules/shared/services/notification.service';

@Injectable({
  providedIn: 'root',
})
export class AuthorizationService {
  constructor(
    private jwtHelperService: JwtHelperService,
    private notificationService: NotificationService
  ) {}

  get isAdmin(): boolean {
    return (
      this.isLoggedIn() &&
      this.getUserRoles() &&
      this.getUserRoles().includes(Role.Admin)
    );
  }

  getUserRoles(): any {
    const decodeToken = this.getDecodeToken();
    const roles = decodeToken && decodeToken['role'];
    return roles;
  }

  isLoggedIn(): boolean {
    const decodedToken = this.getDecodeToken();
    if (!decodedToken || this.isExpired(decodedToken.exp * 1000)) {
      return false;
    }
    return true;
  }

  isExpired(milliseconds: number): boolean {
    return milliseconds < new Date().getTime();
  }

  getDecodeToken() {
    const token = localStorage.getItem('token');
    const decodeToken = this.jwtHelperService.decodeToken(token);
    return decodeToken;
  }

  private allowedRolesIsEmpty(allowedRoles: string[]) {
    return allowedRoles == null || allowedRoles.length === 0;
  }

  isAuthorized(allowedRoles: string[]): boolean {
    // check if the list of allowed roles is empty, if empty, authorize the user to access the page
    if (this.allowedRolesIsEmpty(allowedRoles)) return true;
    // if (allowedRoles == null || allowedRoles.length === 0) {
    //   return true;
    // }

    const decodedToken = this.getDecodeToken();

    // check if it was decoded successfully, if not the token is not valid, deny access
    if (!decodedToken) {
      this.notificationService.showMessage('Invalid Token');
      return false;
    }

    // check if the user roles is in the list of allowed roles, return true if allowed and false if not allowed
    return allowedRoles.includes(decodedToken['role']);
  }
}
