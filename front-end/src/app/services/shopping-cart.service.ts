import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { ComicShopItem } from '../models/comic-shop-item.model';
import { NotificationService } from '../modules/shared/services/notification.service';
import { CartItem } from './../models/cart-item.model';

@Injectable({
  providedIn: 'root',
})
export class ShoppingCartService {
  constructor(private notificationService: NotificationService) {}

  private itemsSource$ = new BehaviorSubject<CartItem[]>([]);
  items$: Observable<CartItem[]> = this.itemsSource$.asObservable();

  get hasItems(): boolean {
    return !!this.itemsSource$.value.length;
  }

  get totalItems(): number {
    return this.itemsSource$.value.reduce((acc, cur) => acc + cur.quantity, 0);
  }

  public quantityUp(item: CartItem, quantity: number = 1): void {
    const expectations = [
      {
        expect: () => item.hasItemsAvailable(quantity) === false,
        action: () => {
          this.notificationService.showMessage(
            'Não há itens disponíveis para está quantidade'
          );
        },
      },
      {
        expect: () => true,
        action: () => {
          item.quantityUp(quantity);
          this.itemsSource$.next([...this.itemsSource$.value]);
        },
      },
    ];

    const currentExpect = expectations.find((c) => c.expect());
    currentExpect.action();
  }

  public quantityDown(item: CartItem): void {
    item.quantityDown();
    this.itemsSource$.next([...this.itemsSource$.value]);
  }

  public addItem(item: ComicShopItem, quantity: number = 1) {
    const foundItem = this.itemsSource$.value.find(
      (c) => c.comic.comicID === item.comicID
    );

    const expectations = [
      {
        expect: () =>
          quantity > item.inventoryQuantity ||
          (foundItem !== undefined &&
            foundItem.hasItemsAvailable(quantity) === false),
        action: () => {
          this.notificationService.showMessage(
            'Não há itens disponíveis para está quantidade'
          );
        },
      },
      {
        expect: () => foundItem !== undefined,
        action: () => {
          this.quantityUp(foundItem, quantity);
          this.itemsSource$.next(this.itemsSource$.value);
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
