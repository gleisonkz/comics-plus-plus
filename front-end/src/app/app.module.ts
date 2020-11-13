import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { HeaderComponent } from './components/header/header.component';
import { ToggleThemeComponent } from './components/toggle-theme/toggle-theme.component';
import { ComicsComponent } from './pages/comics/comics.component';
import { AboutComponent } from './pages/about/about.component';
import { ComicComponent } from './components/comic/comic.component';
import { ComicDetailComponent } from './pages/comic-detail/comic-detail.component';

import { MatBadgeModule } from '@angular/material/badge';
import { MatInputModule } from '@angular/material/input';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    ToggleThemeComponent,
    ComicsComponent,
    AboutComponent,
    ComicComponent,
    ComicDetailComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatBadgeModule,
    MatInputModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
