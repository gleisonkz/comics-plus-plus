import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorHandler, NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { JwtModule } from '@auth0/angular-jwt';
import { NgxMaskModule } from 'ngx-mask';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ComicComponent } from './components/comic/comic.component';
import { HeaderComponent } from './components/header/header.component';
import { ShoppingCartComponent } from './components/shopping-cart/shopping-cart.component';
import { ToggleThemeComponent } from './components/toggle-theme/toggle-theme.component';
import { ShowValidationDirective } from './directives/show-validation.directive';
import { QueryParamsInterceptor } from './interceptors/query-params.interceptor';
import { JwtInterceptor } from './modules/authentication/interceptors/jwt.interceptor';
import { MaterialModule } from './modules/material/material.module';
import { ApplicationErrorHandler } from './modules/shared/classes/application-error-handler';
import { AboutComponent } from './pages/about/about.component';
import { ComicDetailComponent } from './pages/comic-detail/comic-detail.component';
import { ComicsComponent } from './pages/comics/comics.component';
import { HomeComponent } from './pages/home/home.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';

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
    ShoppingCartComponent,
    NotFoundComponent,
    ShowValidationDirective,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,
    MaterialModule,
    FlexLayoutModule,
    NgxMaskModule.forRoot(),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
      },
    }),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: QueryParamsInterceptor,
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true,
    },
    { provide: ErrorHandler, useClass: ApplicationErrorHandler },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}

export function tokenGetter() {
  return localStorage.getItem('access_token');
}
