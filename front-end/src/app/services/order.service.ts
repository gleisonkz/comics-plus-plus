import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Order } from '../models/order.model';
import { CartItem } from './../models/cart-item.model';
import { ShoppingCartService } from './shopping-cart.service';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  constructor(
    private shoppingCartService: ShoppingCartService,
    private http: HttpClient
  ) {}

  getTotalValue(): number {
    return this.shoppingCartService.getTotal();
  }

  postOrder(order: Order): Observable<Order> {
    return this.http.post<Order>(`${environment.apiURL}/orders`, order);
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
