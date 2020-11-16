import { Comic } from './comic.model';

export class CartItem {
  constructor(public comic: Comic, public quantity: number = 1) {}

  getTotalValue(): number {
    return this.comic.price * this.quantity;
  }

  quantityUp() {
    this.quantity++;
  }

  quantityDown() {
    this.quantity > 1 && this.quantity--;
  }
}
