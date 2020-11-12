import { ToggleThemeService } from './services/toggle-theme.service';
import { DOCUMENT } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'comics-plus-plus';
  subscription: Subscription;

  constructor(
    private toggleThemeService: ToggleThemeService,
    @Inject(DOCUMENT) private documentRef: Document
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
