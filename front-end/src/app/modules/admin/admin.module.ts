import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { GenreService } from '../../services/genre.service';
import { MaterialModule } from '../material/material.module';
import { SharedModule } from '../shared/shared.module';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { AuthorCrudComponent } from './components/author-crud/author-crud.component';
import { ComicCrudComponent } from './components/comic-crud/comic-crud.component';
import { AuthorDialogComponent } from './components/dialogs/author-dialog/author-dialog.component';
import { ComicDialogComponent } from './components/dialogs/comic-dialog/comic-dialog.component';
import { ConfirmationDialogComponent } from './components/dialogs/confirmation-dialog/confirmation-dialog.component';
import { GenreDialogComponent } from './components/dialogs/genre-dialog/genre-dialog.component';
import { GenreCrudComponent } from './components/genre-crud/genre-crud.component';

@NgModule({
  declarations: [
    AdminComponent,
    ComicCrudComponent,
    GenreCrudComponent,
    GenreDialogComponent,
    ConfirmationDialogComponent,
    AuthorCrudComponent,
    AuthorDialogComponent,
    ComicDialogComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
    SharedModule,
  ],
  providers: [GenreService],
})
export class AdminModule {}
