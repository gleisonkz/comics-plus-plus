import { Component, Input, OnInit } from '@angular/core';
import { ComicShopItem } from 'src/app/models/comic-shop-item.model';
import { ShoppingCartService } from 'src/app/services/shopping-cart.service';
import { FileUploadService } from '../../services/file-upload.service';

@Component({
  selector: 'cms-comic',
  templateUrl: './comic.component.html',
  styleUrls: ['./comic.component.scss'],
})
export class ComicComponent implements OnInit {
  @Input() comic: ComicShopItem;

  get isInventoryAvailable() {
    return this.comic.inventoryQuantity > 0;
  }

  constructor(
    private shoppingCartService: ShoppingCartService,
    private fileUploadService: FileUploadService
  ) {}

  ngOnInit(): void {
    this.comic.image.preview = this.fileUploadService.loadImagePreview(
      this.comic.image
    );
  }

  addToCart(comic: ComicShopItem) {
    if (!this.isInventoryAvailable) return;
    this.shoppingCartService.addItem(comic);
  }
}
