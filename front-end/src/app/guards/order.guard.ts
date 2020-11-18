import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from '@angular/router';

import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class OrderGuard implements CanActivate {
  constructor(private router: Router) {}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    if (sessionStorage.getItem('orderID') === null) {
      this.router.navigateByUrl('/livros');
      return false;
    }
    return true;
  }
}
