import {
  AuthorCrudComponent,
  GenreCrudComponent,
  InventoryCrudComponent
} from '@admin/pages';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizationGuard } from '@core/guards';
import { AdminComponent } from './pages/admin/admin.component';
import { AuthorTestComponent } from './pages/author-test/author-test.component';
import { ComicCrudComponent } from './pages/comic-crud/comic-crud.component';

const routes: Routes = [
  {
    path: '',
    component: AdminComponent,
    canActivateChild: [AuthorizationGuard],
    children: [
      {
        path: '',
        redirectTo: 'comic',
        pathMatch: 'full'
      },
      {
        path: 'comic',
        component: ComicCrudComponent,
        data: { allowedRoles: ['Admin'] }
      },
      {
        path: 'author',
        component: AuthorCrudComponent,
        data: { allowedRoles: ['Admin'] }
      },
      {
        path: 'author-test',
        component: AuthorTestComponent,
        data: { allowedRoles: ['Admin'] }
      },
      {
        path: 'genre',
        component: GenreCrudComponent,
        data: { allowedRoles: ['Admin'] }
      },
      {
        path: 'inventory',
        component: InventoryCrudComponent,
        data: { allowedRoles: ['Admin'] }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule {}
