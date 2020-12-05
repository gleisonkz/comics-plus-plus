import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from './../material/material.module';
import { DropdownListComponent } from './components/dropdown-list/dropdown-list.component';
import { NotificationService } from './services/notification.service';

@NgModule({
  declarations: [DropdownListComponent],
  imports: [CommonModule, MaterialModule, ReactiveFormsModule],
  exports: [DropdownListComponent],
  providers: [NotificationService],
})
export class SharedModule {}
