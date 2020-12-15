import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizationGuard } from './guards/authorization.guard';
import { OrderGuard } from './guards/order.guard';
import { AboutComponent } from './pages/about/about.component';
import { ComicDetailComponent } from './pages/comic-detail/comic-detail.component';
import { ComicsComponent } from './pages/comics/comics.component';
import { HomeComponent } from './pages/home/home.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { OrderFinishedComponent } from './pages/order-finished/order-finished.component';
import { OrderComponent } from './pages/order/order.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'quadrinhos', component: ComicsComponent },
  { path: 'quadrinhos/:id', component: ComicDetailComponent },
  { path: 'sobre', component: AboutComponent },
  {
    path: 'order',
    component: OrderComponent,
    canActivate: [AuthorizationGuard],
    data: { allowedRoles: ['User'] },
  },
  {
    path: 'order-finished',
    component: OrderFinishedComponent,
    canActivate: [OrderGuard],
  },
  {
    path: 'admin',
    loadChildren: () =>
      import('./modules/admin/admin.module').then((m) => m.AdminModule),
  },
  {
    path: 'authentication',
    loadChildren: () =>
      import('./modules/authentication/authentication.module').then(
        (m) => m.AuthenticationModule
      ),
  },
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
