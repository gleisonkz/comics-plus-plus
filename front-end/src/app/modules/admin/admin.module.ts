import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { MaterialModule } from '../material/material/material.module';
import { ComicCrudComponent } from './components/comic-crud/comic-crud.component';
import { GenreCrudComponent } from './components/genre-crud/genre-crud.component';
import { GenreDialogComponent } from './components/dialogs/genre-dialog/genre-dialog.component';
import { ReactiveFormsModule } from '@angular/forms';
import { GenreService } from '../../services/genre.service';
import { ConfirmationDialogComponent } from './components/dialogs/confirmation-dialog/confirmation-dialog.component';
import { AuthorCrudComponent } from './components/author-crud/author-crud.component';
import { AuthorDialogComponent } from './components/dialogs/author-dialog/author-dialog.component';
import { ComicDialogComponent } from './components/dialogs/comic-dialog/comic-dialog.component';
import { DropdownListComponent } from '../../shared/components/dropdown-list/dropdown-list.component';

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
    DropdownListComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
  ],
  providers: [GenreService],
})
export class AdminModule {}
