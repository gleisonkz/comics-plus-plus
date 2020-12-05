import { CommonModule } from '@angular/common';
import {
  CUSTOM_ELEMENTS_SCHEMA,
  NgModule,
  NO_ERRORS_SCHEMA,
} from '@angular/core';
import { DropdownListComponent } from './components/dropdown-list/dropdown-list.component';
import { NotificationService } from './services/notification.service';

@NgModule({
  declarations: [DropdownListComponent],
  imports: [CommonModule],
  exports: [DropdownListComponent],
  providers: [NotificationService],
  schemas: [CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA],
})
export class SharedModule {}
