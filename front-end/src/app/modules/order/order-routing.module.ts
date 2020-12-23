import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizationGuard } from 'src/app/guards/authorization.guard';
import { OrderGuard } from 'src/app/guards/order.guard';
import { OrderFinishedComponent } from 'src/app/modules/order/pages/order-finished/order-finished.component';
import { OrderComponent } from './pages/order/order.component';

const routes: Routes = [
  {
    path: '',
    component: OrderComponent,
    canActivate: [AuthorizationGuard],
    data: { allowedRoles: ['User'] },
  },
  {
    path: 'order-finished',
    component: OrderFinishedComponent,
    canActivate: [OrderGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class OrderRoutingModule {}
