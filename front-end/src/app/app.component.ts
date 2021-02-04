import { Component, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { Router, RouterOutlet } from '@angular/router';
import { AuthorizationService } from '@core/services';
import { AuthenticationService } from '@core/services/authentication.service';
import { Subscription } from 'rxjs';
import { fadeAnimation } from './shared/animations/fade-animation';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  animations: [fadeAnimation]
})
export class AppComponent {
  title = 'comics-plus-plus';
  subscription: Subscription;

  @ViewChild('sidenav') public sidenav: MatSidenav;
  @ViewChild('adminSide') public adminSide: MatSidenav;

  get isAdmin() {
    return this.authorizationService.isAdmin;
  }

  get isLoggedIn(): boolean {
    return this.authorizationService.isLoggedIn();
  }

  constructor(
    private authorizationService: AuthorizationService,
    private authenticationService: AuthenticationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.subscription.add(
      this.router.events.subscribe(() => {
        this.sidenav.close();
        this.adminSide.close();
      })
    );
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  getRouterOutletState(outlet: RouterOutlet) {
    return outlet && outlet.activatedRouteData && outlet.activatedRouteData;
  }

  logout(): void {
    this.authenticationService.logout();
  }

  prepareRoute(outlet: RouterOutlet) {
    return outlet?.isActivated || '';
  }
}
