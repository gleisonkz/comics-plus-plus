import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatBadgeModule } from '@angular/material/badge';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTabsModule } from '@angular/material/tabs';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import {
  ComicComponent,
  HeaderComponent,
  ShoppingCartComponent,
  ToggleThemeComponent
} from './components';
import {
  AboutComponent,
  ComicDetailComponent,
  ComicsComponent,
  HomeComponent,
  NotFoundComponent
} from './pages';

@NgModule({
  declarations: [
    ComicComponent,
    HeaderComponent,
    ShoppingCartComponent,
    ToggleThemeComponent,
    NotFoundComponent,
    HomeComponent,
    ComicsComponent,
    ComicDetailComponent,
    AboutComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    RouterModule,
    ReactiveFormsModule,
    MatSidenavModule,
    MatListModule,
    MatTabsModule,
    MatIconModule,
    MatBadgeModule,
    MatMenuModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    MatSnackBarModule
  ],
  exports: [
    MatListModule,
    MatSidenavModule,
    ComicComponent,
    HeaderComponent,
    ShoppingCartComponent,
    ToggleThemeComponent,
    NotFoundComponent,
    HomeComponent,
    ComicsComponent,
    ComicDetailComponent,
    AboutComponent,
    BrowserModule,
    BrowserAnimationsModule
  ]
})
export class CoreModule {}
