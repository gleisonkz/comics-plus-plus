import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { AuthorCrudComponent } from './pages/author-crud/author-crud.component';
import { ComicCrudComponent } from './pages/comic-crud/comic-crud.component';
import { GenreCrudComponent } from './pages/genre-crud/genre-crud.component';

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
