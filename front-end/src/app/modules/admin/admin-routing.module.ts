import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizationGuard } from './../../guards/authorization.guard';
import { AdminComponent } from './admin.component';
import { AuthorCrudComponent } from './pages/author-crud/author-crud.component';
import { ComicCrudComponent } from './pages/comic-crud/comic-crud.component';
import { GenreCrudComponent } from './pages/genre-crud/genre-crud.component';

const routes: Routes = [
  {
    path: '',
    component: AdminComponent,
    canActivateChild: [AuthorizationGuard],
    children: [
      {
        path: '',
        redirectTo: 'comic',
        pathMatch: 'full',
      },
      {
        path: 'comic',
        component: ComicCrudComponent,
        data: { allowedRoles: ['Admin'] },
      },
      {
        path: 'author',
        component: AuthorCrudComponent,
        data: { allowedRoles: ['Admin'] },
      },
      {
        path: 'genre',
        component: GenreCrudComponent,
        data: { allowedRoles: ['Admin'] },
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
