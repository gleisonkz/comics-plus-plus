import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatRadioModule } from '@angular/material/radio';
import { OrderItemComponent, RatingComponent } from '@order/components';
import { OrderGuard } from '@order/guards/order.guard';
import { OrderRoutingModule } from '@order/order-routing.module';
import { OrderComponent, OrderFinishedComponent } from '@order/pages';
import { SharedModule } from '@shared/shared.module';

@NgModule({
  declarations: [
    RatingComponent,
    OrderItemComponent,
    OrderComponent,
    OrderFinishedComponent
  ],
  imports: [
    OrderRoutingModule,
    SharedModule,
    MatRadioModule,
    MatFormFieldModule,
    MatButtonModule,
    MatInputModule,
    MatIconModule
  ],
  providers: [OrderGuard]
})
export class OrderModule {}
