import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AdminComponent } from './admin.component';
import { ComicCrudComponent } from './components/comic-crud/comic-crud.component';
import { GenreCrudComponent } from './components/genre-crud/genre-crud.component';
import { AuthorCrudComponent } from './components/author-crud/author-crud.component';

const routes: Routes = [
  {
    path: '',
    component: AdminComponent,
    children: [
      { path: 'comic', component: ComicCrudComponent },
      { path: 'author', component: AuthorCrudComponent },
      { path: 'genre', component: GenreCrudComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
