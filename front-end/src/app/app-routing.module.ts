import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ComicsComponent } from './pages/comics/comics.component';
import { AboutComponent } from './pages/about/about.component';
import { ComicDetailComponent } from './pages/comic-detail/comic-detail.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'livros', component: ComicsComponent },
  { path: 'livros/:id', component: ComicDetailComponent },
  { path: 'sobre', component: AboutComponent },
  { path: 'admin', component: AboutComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
