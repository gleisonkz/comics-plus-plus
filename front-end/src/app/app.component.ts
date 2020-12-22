import { DOCUMENT } from '@angular/common';
import { Component, Inject, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { Router, RouterOutlet } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthenticationService } from './modules/authentication/services/authentication.service';
import { fadeAnimation } from './modules/shared/animations/fade.animations';
import { NotificationService } from './modules/shared/services/notification.service';
import { AuthorizationService } from './services/authorization.service';
import { ToggleThemeService } from './services/toggle-theme.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  animations: [fadeAnimation],
})
export class AppComponent {
  title = 'comics-plus-plus';
  subscriptions: Subscription[] = [];
  @ViewChild('sidenav') public sidenav: MatSidenav;
  @ViewChild('adminSide') public adminSide: MatSidenav;

  get isAdmin() {
    return this.authorizationService.isAdmin;
  }

  get isLoggedIn(): boolean {
    return this.authorizationService.isLoggedIn();
  }

  constructor(
    private toggleThemeService: ToggleThemeService,
    @Inject(DOCUMENT) private documentRef: Document,
    private authorizationService: AuthorizationService,
    private authenticationService: AuthenticationService,
    private notificationService: NotificationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.subscriptions.push(
      this.toggleThemeService.changeTheme.subscribe(() => {
        this.documentRef.documentElement.classList.toggle('dark-mode');
      })
    );

    this.subscriptions.push(
      this.router.events.subscribe(() => {
        this.sidenav.close();
        this.adminSide.close();
      })
    );
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach((c) => c.unsubscribe());
  }

  getRouterOutletState(outlet: RouterOutlet) {
    return outlet.isActivated ? outlet.activatedRoute : '';
  }

  logout(): void {
    this.authenticationService.logout();
    this.notificationService.showMessage('Logout efetuado com sucesso!');
  }
}
