import { ComicShopItem } from './comic-shop-item.model';
export class CartItem {
  private _quantity: number = 0;
  get quantity(): number {
    return this._quantity;
  }
  constructor(public comic: ComicShopItem, quantity: number = 1) {
    this.quantityUp(quantity);
  }

  getTotalValue(): number {
    return this.comic.price * this.quantity;
  }

  hasItemsAvailable(quantity: number): boolean {
    return this.quantity + quantity <= this.comic.inventoryQuantity;
  }

  quantityUp(quantity: number) {
    if (this.hasItemsAvailable(quantity) === false) {
      return;
    }
    this._quantity += quantity;
  }

  quantityDown() {
    this.quantity > 1 && this._quantity--;
  }
}
