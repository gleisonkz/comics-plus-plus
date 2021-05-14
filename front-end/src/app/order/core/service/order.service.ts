import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CartItem } from '@core/models/cart-item.model';
import { ShoppingCartService } from '@core/services';
import { Order } from '@order/models/order.model';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';

@Injectable()
export class OrderService {
  constructor(
    private shoppingCartService: ShoppingCartService,
    private http: HttpClient
  ) {}

  getTotalValue(): number {
    return this.shoppingCartService.getTotal();
  }

  postOrder(order: Order): Observable<Order> {
    return this.http.post<Order>(`${environment.apiURL}/order`, order);
  }

  quantityUp(item: CartItem): void {
    this.shoppingCartService.quantityUp(item);
  }

  quantityDown(item: CartItem): void {
    this.shoppingCartService.quantityDown(item);
  }

  removeItem(item: CartItem): void {
    this.shoppingCartService.removeItem(item);
  }

  clear(): void {
    this.shoppingCartService.clear();
  }
}
