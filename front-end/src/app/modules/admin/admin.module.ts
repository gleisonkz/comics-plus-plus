import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { MaterialModule } from '../material/material/material.module';
import { ComicCrudComponent } from './components/comic-crud/comic-crud.component';

@NgModule({
  declarations: [AdminComponent, ComicCrudComponent],
  imports: [CommonModule, AdminRoutingModule, MaterialModule],
})
export class AdminModule {}
