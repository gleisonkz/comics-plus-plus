import { Component, Input, OnInit } from '@angular/core';
import { ComicShopItem } from '@core/models/comic-shop-item.model';
import { ShoppingCartService } from '@core/services';
import { environment } from './../../../../environments/environment';

@Component({
  selector: 'cms-comic',
  templateUrl: './comic.component.html',
  styleUrls: ['./comic.component.scss']
})
export class ComicComponent implements OnInit {
  @Input() comic: ComicShopItem;

  get isInventoryAvailable() {
    return this.comic.inventoryQuantity > 0;
  }

  constructor(private shoppingCartService: ShoppingCartService) {}

  ngOnInit(): void {
    this.comic.imagePreview = `${environment.apiURL}/comic/${this.comic.comicID}/image`;
  }

  addToCart(comic: ComicShopItem) {
    if (!this.isInventoryAvailable) return;
    this.shoppingCartService.addItem(comic);
  }
}
