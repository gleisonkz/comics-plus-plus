import { ApplicationErrorHandler } from './classes/application-error-handler';
import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { HeaderComponent } from './components/header/header.component';
import { ToggleThemeComponent } from './components/toggle-theme/toggle-theme.component';
import { ComicsComponent } from './pages/comics/comics.component';
import { AboutComponent } from './pages/about/about.component';
import { ComicComponent } from './components/comic/comic.component';
import { ComicDetailComponent } from './pages/comic-detail/comic-detail.component';

import { ShoppingCartComponent } from './components/shopping-cart/shopping-cart.component';
import { ReactiveFormsModule } from '@angular/forms';
import { OrderComponent } from './pages/order/order.component';
import { OrderItemComponent } from './components/order-item/order-item.component';
import { MaterialModule } from './modules/material/material/material.module';
import { OrderFinishedComponent } from './pages/order-finished/order-finished.component';
import { RatingComponent } from './components/rating/rating.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { QueryParamsInterceptor } from './shared/interceptors/query-params.interceptor';

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
    OrderComponent,
    OrderItemComponent,
    OrderFinishedComponent,
    RatingComponent,
    NotFoundComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,
    MaterialModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: QueryParamsInterceptor,
      multi: true,
    },
    { provide: ErrorHandler, useClass: ApplicationErrorHandler },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
