import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AdminComponent } from './admin.component';
import { ComicCrudComponent } from './components/comic-crud/comic-crud.component';

const routes: Routes = [
  {
    path: '',
    component: AdminComponent,
    children: [
      { path: 'comic', component: ComicCrudComponent },
      { path: 'author', component: ComicCrudComponent },
      { path: 'genre', component: ComicCrudComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
