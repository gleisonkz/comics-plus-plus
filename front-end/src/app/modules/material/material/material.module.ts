import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatRadioModule } from '@angular/material/radio';
import { MatInputModule } from '@angular/material/input';
import { MatTabsModule } from '@angular/material/tabs';
import { MatMenuModule } from '@angular/material/menu';
import { MatBadgeModule } from '@angular/material/badge';

@NgModule({
  declarations: [],
  imports: [CommonModule],
  exports: [
    MatRadioModule,
    MatInputModule,
    MatBadgeModule,
    MatInputModule,
    MatMenuModule,
    MatTabsModule,
  ],
})
export class MaterialModule {}
