import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ReactiveFormsModule } from '@angular/forms';
import { GenreService } from '../../services/genre.service';
import { MaterialModule } from '../material/material.module';
import { SharedModule } from '../shared/shared.module';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import {
  AddButtonComponent,
  AuthorDialogComponent,
  ComicDialogComponent,
  ComicInventoryDialogComponent,
  ConfirmationDialogComponent,
  GenreDialogComponent,
} from './components';
import {
  AuthorCrudComponent,
  ComicCrudComponent,
  GenreCrudComponent,
} from './pages';
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
