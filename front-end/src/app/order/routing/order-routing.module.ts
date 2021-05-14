import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizationGuard } from '@core/guards';
import { OrderFinishedComponent } from '../presentation/pages/order-finished/order-finished.component';
import { OrderComponent } from '../presentation/pages/order/order.component';
import { OrderGuard } from './guards/order.guard';

const routes: Routes = [
  {
    path: '',
    component: OrderComponent,
    canActivate: [AuthorizationGuard],
    data: { allowedRoles: ['User'] }
  },
  {
    path: 'order-finished',
    component: OrderFinishedComponent,
    canActivate: [OrderGuard]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrderRoutingModule {}
