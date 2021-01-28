import { Component, Input, OnInit } from '@angular/core';
import { ComicShopItem } from '@core/models/comic-shop-item.model';
import { ComicService, ShoppingCartService } from '@core/services';

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

  constructor(
    private shoppingCartService: ShoppingCartService,
    private comicService: ComicService
  ) {}

  ngOnInit(): void {
    this.comic.imagePreview = this.comicService.getComicImageUrlByComicID(
      this.comic.comicID
    );
  }

  addToCart(comic: ComicShopItem) {
    if (!this.isInventoryAvailable) return;
    this.shoppingCartService.addItem(comic);
  }
}
