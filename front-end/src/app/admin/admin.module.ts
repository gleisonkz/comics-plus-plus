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
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatTableModule } from '@angular/material/table';
import { GenreService } from '@core/services';
import { SharedModule } from '@shared/shared.module';
import { MaterialFileInputModule } from 'ngx-material-file-input';
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
  imports: [
    FlexLayoutModule,
    AdminRoutingModule,
    SharedModule,
    MatFormFieldModule,
    MatInputModule,
    MatDividerModule,
    MatExpansionModule,
    MatListModule,
    MatSidenavModule,
    MatDialogModule,
    MatPaginatorModule,
    MatTableModule,
    MatIconModule,
    MatMenuModule,
    MatButtonModule,
    MaterialFileInputModule
  ],
  providers: [GenreService]
})
export class AdminModule {}
