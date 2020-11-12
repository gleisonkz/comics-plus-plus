import { Component } from '@angular/core';
import { ToggleThemeService } from 'src/app/services/toggle-theme.service';

@Component({
  selector: 'mt-toggle-theme',
  templateUrl: './toggle-theme.component.html',
  styleUrls: ['./toggle-theme.component.scss'],
})
export class ToggleThemeComponent {
  constructor(private toggleThemeService: ToggleThemeService) {}

  changeTheme(): void {
    this.toggleThemeService.ToggleTheme();
  }
}
