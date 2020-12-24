import { CommonModule } from '@angular/common';
import { ErrorHandler, NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxMaskModule } from 'ngx-mask';
import { NotificationService } from '../../services/notification.service';
import { MaterialModule } from './../material/material.module';
import { ApplicationErrorHandler } from './classes/application-error-handler';
import { DropdownListComponent } from './components/dropdown-list/dropdown-list.component';
import { ShowValidationDirective } from './directives/show-validation.directive';

@NgModule({
  declarations: [DropdownListComponent, ShowValidationDirective],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    NgxMaskModule.forRoot(),
  ],
  exports: [
    CommonModule,
    DropdownListComponent,
    MaterialModule,
    ReactiveFormsModule,
    ShowValidationDirective,
    NgxMaskModule,
  ],
  providers: [
    NotificationService,
    { provide: ErrorHandler, useClass: ApplicationErrorHandler },
  ],
})
export class SharedModule {}
