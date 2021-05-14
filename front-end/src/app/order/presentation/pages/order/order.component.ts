import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CartItem } from '@core/models/cart-item.model';
import { ShoppingCartService } from '@core/services';
import { CustomerService, OrderService } from '@order/core/service';
import { PaymentMethod } from '@order/presentation/enums/payment-method.enum';
import { OrderItem } from '@order/presentation/models/order-item.model';
import { Order } from '@order/presentation/models/order.model';
import { CEP, cep } from 'cep-promise';
import { Observable, Subscription } from 'rxjs';
import { NotificationService } from '../../../../core/services/notification.service';

@Component({
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {
  public get hasItems() {
    return this.cartService.hasItems;
  }

  public orderForm: FormGroup;
  public orderItems$: Observable<CartItem[]>;
  public deliveryCost: number = 8.0;
  private subscription: Subscription;

  constructor(
    private router: Router,
    private cartService: ShoppingCartService,
    private orderService: OrderService,
    private customerService: CustomerService,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    this.orderForm = new FormGroup({
      postalCode: new FormControl('', [Validators.required, this.postalCode]),
      line1: new FormControl('', [Validators.required]),
      number: new FormControl('', [Validators.required, Validators.maxLength(6), Validators.pattern('\\d+')]),
      line2: new FormControl(''),
      neighborhood: new FormControl('', Validators.required),
      city: new FormControl('', Validators.required),
      state: new FormControl('', [Validators.required]),
      paymentMethodID: new FormControl(PaymentMethod.Cash, [Validators.required])
    });

    this.orderItems$ = this.cartService.items$;
  }

  private hasEightDigits(value: string): boolean {
    return /\d{8}/.test(value);
  }

  private postalCode(postalCode: FormControl): { [key: string]: string } {
    if (postalCode.value.length !== 8) {
      return { postalCodeError: 'o CEP deve conter 8 dígitos' };
    }

    return undefined;
  }

  getTotalItems(): number {
    return this.orderService.getTotalValue();
  }

  getOrderItems(): OrderItem[] {
    let orderItems: OrderItem[];
    this.subscription.add(
      this.orderItems$.subscribe(
        (items) =>
          (orderItems = items.map((c: CartItem) => ({
            quantity: c.quantity,
            comicID: c.comic.comicID
          })))
      )
    );

    return orderItems;
  }

  searchCEP(numberCEP: string): void {
    if (!numberCEP || !this.hasEightDigits(numberCEP)) return;

    cep(numberCEP, { providers: ['correios'] })
      .then((cep) => {
        this.updateAddress(cep);
      })
      .catch(() => {
        this.notificationService.showMessage('CEP inválido, todos os serviços de CEP retornaram erro');
      });
  }

  private updateAddress(cep: CEP): void {
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
      this.router.navigate(['order/order-finished'], {
        state: { order: order }
      });

      this.orderService.clear();
    });
  }
}
