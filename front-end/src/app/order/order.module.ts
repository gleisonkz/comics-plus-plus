import { NgModule } from '@angular/core';
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
  imports: [OrderRoutingModule, SharedModule],
  providers: [OrderGuard]
})
export class OrderModule {}
