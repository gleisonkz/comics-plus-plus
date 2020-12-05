import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ComicShopItemDetail } from '../../models/comic-shop-item-detail.model';
import { ComicService } from '../../services/comic.service';
import { FileUploadService } from '../../services/file-upload.service';
import { ShoppingCartService } from '../../services/shopping-cart.service';

@Component({
  selector: 'cms-comic-detail',
  templateUrl: './comic-detail.component.html',
  styleUrls: ['./comic-detail.component.scss'],
})
export class ComicDetailComponent implements OnInit {
  comic: ComicShopItemDetail;
  comicForm: FormGroup;
  get hasCartItems(): boolean {
    return this.shoppingCartService.hasItems;
  }

  constructor(
    private route: ActivatedRoute,
    private comicService: ComicService,
    private shoppingCartService: ShoppingCartService,
    private fileUploadService: FileUploadService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.comicForm = new FormGroup({
      quantity: new FormControl('1', [
        Validators.required,
        Validators.minLength(1),
      ]),
    });

    const comicID = +this.route.snapshot.params.id;

    this.comicService.getComicShopItemDetailByID(comicID).subscribe((comic) => {
      this.comic = comic;
      this.comic.image.preview = this.fileUploadService.loadImagePreview(
        comic.image
      );
    });
  }

  addMultipleItemsToCart(comic: ComicShopItemDetail) {
    this.shoppingCartService.addItem(
      comic,
      +this.comicForm.controls.quantity.value
    );
  }

  navigateToOrder(): void {
    this.hasCartItems && this.router.navigate(['/order']);
  }
}
