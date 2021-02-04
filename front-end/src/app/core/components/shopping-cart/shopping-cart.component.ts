import { Component, OnInit, ViewChild } from '@angular/core';
import { MatMenuTrigger } from '@angular/material/menu';
import { CartItem } from '@core/models/cart-item.model';
import { Observable } from 'rxjs';
import { ShoppingCartService } from '../../services/shopping-cart.service';

@Component({
  selector: 'cms-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.scss']
})
export class ShoppingCartComponent implements OnInit {
  itemState = 'ready';
  items$: Observable<CartItem[]>;

  get hasItems(): boolean {
    return this.shoppingCartService.hasItems;
  }

  get totalItems(): number {
    const quantity = this.shoppingCartService.totalItems;
    return quantity;
  }

  @ViewChild(MatMenuTrigger) notificationMenuBtn: MatMenuTrigger;

  constructor(private shoppingCartService: ShoppingCartService) {}

  ngOnInit(): void {
    this.items$ = this.shoppingCartService.items$;
  }

  getTotal(): number {
    return this.shoppingCartService.getTotal();
  }

  quantityUp(item: CartItem): void {
    this.shoppingCartService.addItem(item.comic);
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

  closeMenu(): void {
    this.notificationMenuBtn.closeMenu();
  }
}
