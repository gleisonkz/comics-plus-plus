import { NgModule } from '@angular/core';
import { OrderFinishedComponent } from 'src/app/modules/order/pages/order-finished/order-finished.component';
import { SharedModule } from '../shared/shared.module';
import { OrderItemComponent } from './components/order-item/order-item.component';
import { RatingComponent } from './components/rating/rating.component';
import { OrderRoutingModule } from './order-routing.module';
import { OrderComponent } from './pages/order/order.component';

@NgModule({
  declarations: [
    RatingComponent,
    OrderItemComponent,
    OrderComponent,
    OrderFinishedComponent,
  ],
  imports: [OrderRoutingModule, SharedModule],
})
export class OrderModule {}
