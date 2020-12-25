import { CommonModule } from '@angular/common';
import { ErrorHandler, NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { CustomErrorStateMatcher } from '@core/classes/custom-error-state-matcher';
import { NotificationService } from '@core/services';
import { ApplicationErrorHandler } from '@shared/classes/application-error-handler';
import { DropdownListComponent } from '@shared/components/dropdown-list/dropdown-list.component';
import { ShowValidationDirective } from '@shared/directives/show-validation.directive';
import { NgxMaskModule } from 'ngx-mask';
import { NgxMatSelectSearchModule } from 'ngx-mat-select-search';

@NgModule({
  declarations: [DropdownListComponent, ShowValidationDirective],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    NgxMaskModule.forRoot(),
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    NgxMatSelectSearchModule
  ],
  exports: [
    CommonModule,
    ReactiveFormsModule,
    DropdownListComponent,
    ShowValidationDirective,
    NgxMaskModule
  ],
  providers: [
    NotificationService,
    { provide: ErrorHandler, useClass: ApplicationErrorHandler },
    { provide: ErrorStateMatcher, useValue: new CustomErrorStateMatcher() }
  ]
})
export class SharedModule {}
