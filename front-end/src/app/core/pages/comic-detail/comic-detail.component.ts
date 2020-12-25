import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ComicShopItemDetail } from '@core/models/comic-shop-item-detail.model';
import {
  ComicService,
  FileUploadService,
  NotificationService,
  ShoppingCartService
} from '@core/services';

@Component({
  selector: 'cms-comic-detail',
  templateUrl: './comic-detail.component.html',
  styleUrls: ['./comic-detail.component.scss']
})
export class ComicDetailComponent implements OnInit {
  comic: ComicShopItemDetail;
  comicForm: FormGroup;

  get hasCartItems(): boolean {
    return this.shoppingCartService.hasItems;
  }

  get isInventoryAvailable() {
    return this.comic?.inventoryQuantity > 0;
  }

  constructor(
    private route: ActivatedRoute,
    private comicService: ComicService,
    private shoppingCartService: ShoppingCartService,
    private notificationService: NotificationService,
    private fileUploadService: FileUploadService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.comicForm = new FormGroup({
      quantity: new FormControl('1', [
        Validators.required,
        Validators.minLength(1)
      ])
    });

    const comicID = +this.route.snapshot.params.id;

    this.comicService.getComicShopItemDetailByID(comicID).subscribe((comic) => {
      this.comic = comic;
      this.comic.image.preview = this.fileUploadService.loadImagePreview(
        comic.image
      );
    });
  }

  addMultipleItemsToCart(comic: ComicShopItemDetail, quantity: number) {
    if (this.isFormInvalid()) {
      this.notificationService.showMessage('O formulário está inválido');
      return;
    }
    this.shoppingCartService.addItem(comic, quantity);
  }

  private isFormInvalid(): boolean {
    return this.comicForm.invalid;
  }
  navigateToOrder(): void {
    this.hasCartItems && this.router.navigate(['/order']);
  }
}
