import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  CanActivateChild,
  Router,
  RouterStateSnapshot
} from '@angular/router';
import { AuthorizationService, NotificationService } from '@core/services';
import { Observable } from 'rxjs';
import { AccessStatus } from '../enums/access-status.enum';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationGuard implements CanActivate, CanActivateChild {
  constructor(
    private authorizationService: AuthorizationService,
    private router: Router,
    private notificationService: NotificationService
  ) {}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> | Promise<boolean> | boolean {
    const allowedRoles = next.data.allowedRoles;
    return this.isAuthorized(allowedRoles);
  }
  canActivateChild(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> | Promise<boolean> | boolean {
    const allowedRoles = next.data.allowedRoles;
    return this.isAuthorized(allowedRoles);
  }

  private isAuthorized(allowedRoles: string[]): boolean {
    const userAccessStatus: AccessStatus = this.authorizationService.isAuthorized(
      allowedRoles
    );

    if (userAccessStatus === AccessStatus.Denied) {
      this.router.navigate(['/authentication/login']);
      this.notificationService.showMessage(
        'O seu usuário não possui autorização para acessar está rota'
      );
      return false;
    } else if (userAccessStatus === AccessStatus.NotLogged) {
      this.router.navigate(['/authentication/login']);
      this.notificationService.showMessage(
        'É necessário estar logado para acessar está rota'
      );
      return false;
    }

    return true;
  }
}
