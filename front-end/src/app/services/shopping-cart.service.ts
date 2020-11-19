import { CartItem } from './../models/cart-item.model';

import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Comic } from '../models/comic.model';

@Injectable({
  providedIn: 'root',
})
export class ShoppingCartService {
  constructor() {}

  private itemsSource$ = new BehaviorSubject<CartItem[]>([]);
  items$: Observable<CartItem[]> = this.itemsSource$.asObservable();

  get hasItems(): boolean {
    return !!this.itemsSource$.value.length;
  }

  get totalItems(): number {
    return this.itemsSource$.value.reduce((acc, cur) => acc + cur.quantity, 0);
  }

  public quantityUp(item: CartItem, quantity: number = 1): void {
    item.quantityUp(quantity);
    this.itemsSource$.next([...this.itemsSource$.value]);
  }

  public quantityDown(item: CartItem): void {
    item.quantityDown();
    this.itemsSource$.next([...this.itemsSource$.value]);
  }

  public addItem(item: Comic, quantity: number = 1) {
    const foundItem = this.itemsSource$.value.find(
      (c) => c.comic.id === item.id
    );

    const expectations = [
      {
        expect: () => foundItem !== undefined,
        action: () => {
          this.quantityUp(foundItem, quantity);
          // this.itemsSource$.next(this.itemsSource$.value);
        },
      },
      {
        expect: () => true,
        action: () =>
          this.itemsSource$.next([
            ...this.itemsSource$.value,
            new CartItem(item, quantity),
          ]),
      },
    ];
    const currentExpect = expectations.find((c) => c.expect());
    currentExpect.action();
  }

  // public addMultipleItemsToCart(item: Comic, quantity: number) {
  //   for (let index = 0; index < quantity; index++) {
  //     this.addItem(item);
  //   }
  // }

  public removeItem(item: CartItem) {
    const items = this.itemsSource$.value;
    items.splice(items.indexOf(item), 1);
    this.itemsSource$.next(items);
  }

  public clear() {
    this.itemsSource$.next([]);
  }

  public getTotal(): number {
    return this.itemsSource$.value.reduce(
      (acc, cur) => acc + cur.getTotalValue(),
      0
    );
  }
}