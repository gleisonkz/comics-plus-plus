import { Component, Input, OnInit } from '@angular/core';
import { CartItem } from '@core/models/cart-item.model';
import { OrderService } from '@order/services';

@Component({
  selector: 'cms-order-item',
  templateUrl: './order-item.component.html',
  styleUrls: ['./order-item.component.scss']
})
export class OrderItemComponent implements OnInit {
  @Input() item: CartItem;

  constructor(private orderService: OrderService) {}

  ngOnInit(): void {}

  quantityUp(item: CartItem): void {
    this.orderService.quantityUp(item);
  }

  quantityDown(item: CartItem): void {
    this.orderService.quantityDown(item);
  }

  removeItem(item: CartItem): void {
    this.orderService.removeItem(item);
  }
}
