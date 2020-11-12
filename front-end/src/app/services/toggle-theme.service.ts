import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ToggleThemeService {
  changeTheme = new Subject();

  constructor() {}
  ToggleTheme(): void {
    this.changeTheme.next();
  }
}
