import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ComicsComponent } from './pages/comics/comics.component';
import { AboutComponent } from './pages/about/about.component';
import { ComicDetailComponent } from './pages/comic-detail/comic-detail.component';
import { OrderComponent } from './pages/order/order.component';
import { OrderFinishedComponent } from './pages/order-finished/order-finished.component';
import { OrderGuard } from './guards/order.guard';
import { NotFoundComponent } from './pages/not-found/not-found.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'livros', component: ComicsComponent },
  { path: 'livros/:id', component: ComicDetailComponent },
  { path: 'sobre', component: AboutComponent },
  { path: 'order', component: OrderComponent },
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
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
