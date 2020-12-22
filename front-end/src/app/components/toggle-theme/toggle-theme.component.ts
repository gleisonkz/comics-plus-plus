import {
  AfterViewInit,
  Component,
  ElementRef,
  OnInit,
  ViewChild,
} from '@angular/core';
import { ToggleThemeService } from 'src/app/services/toggle-theme.service';

@Component({
  selector: 'cms-toggle-theme',
  templateUrl: './toggle-theme.component.html',
  styleUrls: ['./toggle-theme.component.scss'],
})
export class ToggleThemeComponent implements OnInit, AfterViewInit {
  @ViewChild('checkboxTheme') input: ElementRef<HTMLInputElement>;

  constructor(private toggleThemeService: ToggleThemeService) {}

  ngOnInit(): void {
    this.toggleThemeService.setUserTheme();
  }

  ngAfterViewInit(): void {
    const currentTheme = this.toggleThemeService.getCurrentTheme();
    this.input.nativeElement.checked =
      currentTheme === 'dark-mode' ? true : false;
  }

  changeTheme(checked: boolean): void {
    this.toggleThemeService.toggleTheme(checked);
  }
}
