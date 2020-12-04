import { ComicShopItem } from './comic-shop-item.model';
export class CartItem {
  constructor(public comic: ComicShopItem, public quantity: number = 1) {}

  getTotalValue(): number {
    return this.comic.price * this.quantity;
  }

  quantityUp(quantity: number) {
    this.quantity += quantity;
  }

  quantityDown() {
    this.quantity > 1 && this.quantity--;
  }
}
