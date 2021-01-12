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
import { GenreService } from '@admin/services';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatButtonModule } from '@angular/material/button';
import {
  DateAdapter,
  MatNativeDateModule,
  MAT_DATE_FORMATS
} from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatTableModule } from '@angular/material/table';
import { ApplicationDateAdapter } from '@shared/classes/application-date-adapter';
import { APP_DATE_FORMATS } from '@shared/constants/app-date-formats';
import { SharedModule } from '@shared/shared.module';
import { MaterialFileInputModule } from 'ngx-material-file-input';
import { AdminRoutingModule } from './admin-routing.module';
import { BaseCrudComponent } from './pages/base-crud/base-crud.component';
import { AuthorService } from './services/author.service';

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
    BaseCrudComponent
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
    MatProgressSpinnerModule,
    MaterialFileInputModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  providers: [
    GenreService,
    AuthorService,
    {
      provide: DateAdapter,
      useClass: ApplicationDateAdapter
    },
    {
      provide: MAT_DATE_FORMATS,
      useValue: APP_DATE_FORMATS
    }
  ]
})
export class AdminModule {}
