import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { DecodedToken } from '../../authentication/models/decoded-token';
import { AccessStatus } from '../enums/access-status.enum';
import { Role } from '../enums/role.enum';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {
  constructor(private jwtHelperService: JwtHelperService) {}

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

  getDecodeToken(): DecodedToken {
    const token = localStorage.getItem('token');
    const decodedToken: DecodedToken = this.jwtHelperService.decodeToken(token);
    return decodedToken;
  }

  private allowedRolesIsEmpty(allowedRoles: string[]) {
    return allowedRoles == null || allowedRoles.length === 0;
  }

  isAuthorized(allowedRoles: string[]): AccessStatus {
    if (this.allowedRolesIsEmpty(allowedRoles)) return AccessStatus.Granted;

    const decodedToken = this.getDecodeToken();

    if (!this.isLoggedIn()) {
      return AccessStatus.NotLogged;
    }

    const hasAllowedRole = allowedRoles.includes(decodedToken['role'])
      ? AccessStatus.Granted
      : AccessStatus.Denied;

    return hasAllowedRole;
  }
}
