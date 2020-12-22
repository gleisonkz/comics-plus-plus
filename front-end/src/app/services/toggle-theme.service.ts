import { DOCUMENT } from '@angular/common';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ToggleThemeService {
  constructor(@Inject(DOCUMENT) private documentRef: Document) {}
  toggleTheme(checked: boolean): void {
    const theme = checked ? 'dark-mode' : 'light-mode';
    localStorage.setItem('theme', theme);
    this.documentRef.documentElement.className = theme;
  }

  setUserTheme(): void {
    const currentTheme = this.getCurrentTheme();
    this.documentRef.documentElement.className = currentTheme
      ? currentTheme
      : '';
  }

  getCurrentTheme(): string {
    return localStorage.getItem('theme');
  }
}
