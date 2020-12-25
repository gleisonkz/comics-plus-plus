import {
  AddButtonComponent,
  AuthorDialogComponent,
  ComicDialogComponent,
  ComicInventoryDialogComponent,
  ConfirmationDialogComponent,
  GenreDialogComponent
} from '@admin/components';
import {
  AuthorCrudComponent,
  ComicCrudComponent,
  GenreCrudComponent,
  InventoryCrudComponent
} from '@admin/pages';
import { AdminComponent } from '@admin/pages/admin/admin.component';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { GenreService } from '@core/services';
import { SharedModule } from '@shared/shared.module';
import { AdminRoutingModule } from './admin-routing.module';

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
    AddButtonComponent
  ],
  imports: [FlexLayoutModule, AdminRoutingModule, SharedModule],
  providers: [GenreService]
})
export class AdminModule {}
