import { Order } from './../../models/order.model';
import { OrderItem } from './../../models/order-item.model';
import { OrderService } from './../../services/order.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { CartItem } from 'src/app/models/cart-item.model';
import { ShoppingCartService } from 'src/app/services/shopping-cart.service';

@Component({
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss'],
})
export class OrderComponent implements OnInit {
  public orderForm: FormGroup;
  public orderItems$: Observable<CartItem[]>;
  public get hasItems() {
    return this.cartService.hasItems;
  }
  public deliveryCost: number = 8.0;
  private subscriptions: Subscription[] = [];

  constructor(
    private router: Router,
    private cartService: ShoppingCartService,
    private orderService: OrderService
  ) {}

  ngOnInit(): void {
    this.orderForm = new FormGroup({
      name: new FormControl('gleison', [
        Validators.required,
        Validators.minLength(5),
      ]),
      email: new FormControl('gleison@test.com', [
        Validators.required,
        Validators.email,
      ]),
      emailCheck: new FormControl('gleison@test.com', [
        Validators.required,
        Validators.email,
      ]),
      address: new FormControl('street D', [Validators.required]),
      number: new FormControl('07', [Validators.required]),
      address2: new FormControl('block 105', []),
      paymentMethod: new FormControl('1', [Validators.required]),
    });

    this.orderItems$ = this.cartService.items$;
  }

  getTotalItems(): number {
    return this.orderService.getTotalValue();
  }

  getOrderItems(): OrderItem[] {
    let orderItems: OrderItem[];
    this.subscriptions.push(
      this.orderItems$.subscribe(
        (items) =>
          (orderItems = items.map((c: CartItem) => ({
            quantity: c.quantity,
            comicID: c.comic.comicID,
          })))
      )
    );

    return orderItems;
  }

  submitOrder(order: Order): void {
    // order.orderItems = this.getOrderItems();
    // this.orderService.postOrder(order).subscribe((c) => {
    //   order.orderID = c.orderID;
    //   sessionStorage.setItem('orderID', `${c.orderID}`);
    //   this.router.navigate(['/order-finished'], {
    //     state: { order: order },
    //   });

    //   this.orderService.clear();
    // });
    this.orderService.clear();
    this.router.navigate(['/order-finished']);
  }
}
