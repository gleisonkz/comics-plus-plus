import { DOCUMENT } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Subscription } from 'rxjs';
import { Role } from './enums/role.enum';
import { fadeAnimation } from './modules/shared/animations/fade.animations';
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
  subscription: Subscription;
  get isAdmin() {
    return (
      this.authorizationService.getUserRoles &&
      this.authorizationService.getUserRoles().includes(Role.Admin)
    );
  }

  constructor(
    private toggleThemeService: ToggleThemeService,
    @Inject(DOCUMENT) private documentRef: Document,
    private authorizationService: AuthorizationService
  ) {}

  ngOnInit(): void {
    this.subscription = this.toggleThemeService.changeTheme.subscribe(() => {
      this.documentRef.documentElement.classList.toggle('dark-mode');
    });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  public getRouterOutletState(outlet: RouterOutlet) {
    return outlet.isActivated ? outlet.activatedRoute : '';
  }
}
