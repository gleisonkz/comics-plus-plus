import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../material/material.module';
import { ComicComponent } from './components/comic/comic.component';
import { HeaderComponent } from './components/header/header.component';
import { ShoppingCartComponent } from './components/shopping-cart/shopping-cart.component';
import { ToggleThemeComponent } from './components/toggle-theme/toggle-theme.component';
import { AboutComponent } from './pages/about/about.component';
import { ComicDetailComponent } from './pages/comic-detail/comic-detail.component';
import { ComicsComponent } from './pages/comics/comics.component';
import { HomeComponent } from './pages/home/home.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';

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
    CommonModule,
    HttpClientModule,
    RouterModule,
    MaterialModule,
    ReactiveFormsModule
  ],
  exports: [
    ComicComponent,
    HeaderComponent,
    ShoppingCartComponent,
    ToggleThemeComponent,
    NotFoundComponent,
    HomeComponent,
    ComicsComponent,
    ComicDetailComponent,
    AboutComponent,
    MaterialModule
  ]
})
export class CoreModule {}
