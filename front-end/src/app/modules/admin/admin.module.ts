import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ReactiveFormsModule } from '@angular/forms';
import { GenreService } from '../../services/genre.service';
import { MaterialModule } from '../material/material.module';
import { SharedModule } from '../shared/shared.module';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { AddButtonComponent } from './components/add-button/add-button.component';
import { AuthorDialogComponent } from './components/author-dialog/author-dialog.component';
import { ComicDialogComponent } from './components/comic-dialog/comic-dialog.component';
import { ComicInventoryDialogComponent } from './components/comic-inventory-dialog/comic-inventory-dialog.component';
import { ConfirmationDialogComponent } from './components/confirmation-dialog/confirmation-dialog.component';
import { GenreDialogComponent } from './components/genre-dialog/genre-dialog.component';
import { AuthorCrudComponent } from './pages/author-crud/author-crud.component';
import { ComicCrudComponent } from './pages/comic-crud/comic-crud.component';
import { GenreCrudComponent } from './pages/genre-crud/genre-crud.component';
import { InventoryCrudComponent } from './pages/inventory-crud/inventory-crud.component';

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
    InventoryCrudComponent,
    ComicInventoryDialogComponent,
    AddButtonComponent,
  ],
  imports: [
    CommonModule,
    FlexLayoutModule,
    AdminRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
    SharedModule,
  ],
  providers: [GenreService],
})
export class AdminModule {}
