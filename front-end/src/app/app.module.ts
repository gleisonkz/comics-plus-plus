import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorHandler, NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ComicComponent } from './components/comic/comic.component';
import { HeaderComponent } from './components/header/header.component';
import { OrderItemComponent } from './components/order-item/order-item.component';
import { RatingComponent } from './components/rating/rating.component';
import { ShoppingCartComponent } from './components/shopping-cart/shopping-cart.component';
import { ToggleThemeComponent } from './components/toggle-theme/toggle-theme.component';
import { QueryParamsInterceptor } from './interceptors/query-params.interceptor';
import { MaterialModule } from './modules/material/material.module';
import { ApplicationErrorHandler } from './modules/shared/classes/application-error-handler';
import { AboutComponent } from './pages/about/about.component';
import { ComicDetailComponent } from './pages/comic-detail/comic-detail.component';
import { ComicsComponent } from './pages/comics/comics.component';
import { HomeComponent } from './pages/home/home.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { OrderFinishedComponent } from './pages/order-finished/order-finished.component';
import { OrderComponent } from './pages/order/order.component';

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
