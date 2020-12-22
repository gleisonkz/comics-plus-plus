import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import * as getCep from 'cep-promise';
import { Observable, Subscription } from 'rxjs';
import { CartItem } from 'src/app/models/cart-item.model';
import { ShoppingCartService } from 'src/app/services/shopping-cart.service';
import { PaymentMethod } from '../../enums/payment-method.enum';
import { CustomerService } from '../../services/customer.service';
import { OrderItem } from './../../models/order-item.model';
import { Order } from './../../models/order.model';
import { OrderService } from './../../services/order.service';

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
    private orderService: OrderService,
    private customerService: CustomerService
  ) {}

  ngOnInit(): void {
    this.orderForm = new FormGroup({
      postalCode: new FormControl('30580585', [
        Validators.required,
        Validators.minLength(8),
      ]),
      line1: new FormControl('', [Validators.required]),
      number: new FormControl('', [Validators.required]),
      line2: new FormControl(''),
      neighborhood: new FormControl('', Validators.required),
      city: new FormControl('', Validators.required),
      state: new FormControl('', [Validators.required]),
      paymentMethodID: new FormControl(PaymentMethod.BankSlip, [
        Validators.required,
      ]),
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

  searchCEP(cep: string) {
    getCep
      .default(cep)
      .then((cep) => {
        this.updateAddress(cep);
      })
      .catch((err) => {
        throw err;
      });
  }

  private updateAddress(cep) {
    this.orderForm.controls['line1'].setValue(cep.street);
    this.orderForm.controls['state'].setValue(cep.state);
    this.orderForm.controls['neighborhood'].setValue(cep.neighborhood);
    this.orderForm.controls['city'].setValue(cep.city);
  }

  submitOrder(event: Event, order: Order): void {
    event.preventDefault();

    order.customerID = this.customerService.getCustomerID();
    order.orderItems = this.getOrderItems();

    this.orderService.postOrder(order).subscribe((c) => {
      order.orderID = c.orderID;

      sessionStorage.setItem('orderID', `${c.orderID}`);
      this.router.navigate(['/order-finished'], {
        state: { order: order },
      });

      this.orderService.clear();
    });
  }
}
