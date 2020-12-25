import { CommonModule } from '@angular/common';
import { ErrorHandler, NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { NotificationService } from '@core/services';
import { ApplicationErrorHandler } from '@shared/classes/application-error-handler';
import { DropdownListComponent } from '@shared/components/dropdown-list/dropdown-list.component';
import { ShowValidationDirective } from '@shared/directives/show-validation.directive';
import { MaterialModule } from 'app/material/material.module';
import { NgxMaskModule } from 'ngx-mask';

@NgModule({
  declarations: [DropdownListComponent, ShowValidationDirective],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    NgxMaskModule.forRoot()
  ],
  exports: [
    CommonModule,
    DropdownListComponent,
    MaterialModule,
    ReactiveFormsModule,
    ShowValidationDirective,
    NgxMaskModule
  ],
  providers: [
    NotificationService,
    { provide: ErrorHandler, useClass: ApplicationErrorHandler }
  ]
})
export class SharedModule {}
