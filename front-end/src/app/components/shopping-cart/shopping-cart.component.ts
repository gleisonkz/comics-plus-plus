import { Component, OnDestroy, OnInit } from '@angular/core';
import { Comic } from '../../models/comic.model';
import { Observable, Subscription } from 'rxjs';
import { ShoppingCartService } from '../../services/shopping-cart.service';
import { CartItem } from 'src/app/models/cart-item.model';
import {
  animate,
  keyframes,
  state,
  style,
  transition,
  trigger,
} from '@angular/animations';

@Component({
  selector: 'cms-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.scss'],
  // animations: [
  //   trigger('row', [
  //     state('ready', style({ opacity: 1 })),
  //     transition(
  //       'ready => void',
  //       animate(
  //         '300ms 0s ease-out',
  //         keyframes([
  //           style({ opacity: 1, transform: 'translateX(0px)', offset: 0 }),
  //           style({
  //             opacity: 0.8,
  //             transform: 'translateX(-10px)',
  //             offset: 0.2,
  //           }),
  //           style({ opacity: 0, transform: 'translateX(30px)', offset: 1 }),
  //         ])
  //       )
  //     ),
  //   ]),
  // ],
})
export class ShoppingCartComponent implements OnInit, OnDestroy {
  itemState = 'ready';
  items$: Observable<CartItem[]>;
  subscriptions: Subscription[] = [];
  get hasItems(): boolean {
    return this.shoppingCartService.hasItems;
  }

  get totalItems(): number {
    const quantity = this.shoppingCartService.totalItems;
    console.log(quantity);
    return quantity;
  }

  constructor(private shoppingCartService: ShoppingCartService) {}

  ngOnInit(): void {
    this.items$ = this.shoppingCartService.items$;
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach((c) => c.unsubscribe());
  }

  getTotal(): number {
    return this.shoppingCartService.getTotal();
  }

  quantityUp(item: CartItem): void {
    this.shoppingCartService.quantityUp(item);
  }

  quantityDown(item: CartItem): void {
    this.shoppingCartService.quantityDown(item);
  }

  addItem(item: CartItem): void {
    this.shoppingCartService.addItem(item.comic);
  }

  clearCart(): void {
    this.shoppingCartService.clear();
  }

  removeItem(item: CartItem): void {
    this.shoppingCartService.removeItem(item);
  }
}
