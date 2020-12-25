import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from '@core/pages/about/about.component';
import { ComicDetailComponent } from '@core/pages/comic-detail/comic-detail.component';
import { ComicsComponent } from '@core/pages/comics/comics.component';
import { HomeComponent } from '@core/pages/home/home.component';
import { NotFoundComponent } from '@core/pages/not-found/not-found.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'quadrinhos', component: ComicsComponent },
  { path: 'quadrinhos/:id', component: ComicDetailComponent },
  { path: 'sobre', component: AboutComponent },
  {
    path: 'order',
    loadChildren: () => import('@order/order.module').then((m) => m.OrderModule)
  },
  {
    path: 'admin',
    loadChildren: () => import('@admin/admin.module').then((m) => m.AdminModule)
  },
  {
    path: 'authentication',
    loadChildren: () =>
      import('@auth/authentication.module').then((m) => m.AuthenticationModule)
  },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
