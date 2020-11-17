import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Comic } from 'src/app/models/comic.model';
import { ComicService } from '../../services/comic.service';
import { ShoppingCartService } from '../../services/shopping-cart.service';

@Component({
  selector: 'cms-comic-detail',
  templateUrl: './comic-detail.component.html',
  styleUrls: ['./comic-detail.component.scss'],
})
export class ComicDetailComponent implements OnInit {
  comic: Comic;
  comicForm: FormGroup;
  get hasCartItems(): boolean {
    return this.shoppingCartService.hasItems;
  }

  constructor(
    private route: ActivatedRoute,
    private comicService: ComicService,
    private shoppingCartService: ShoppingCartService,
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
    console.log(comicID);

    this.comicService.getComicByID(comicID).subscribe((comic) => {
      this.comic = comic;
    });
  }

  addMultipleItemsToCart(comic: Comic) {
    this.shoppingCartService.addItem(
      comic,
      +this.comicForm.controls.quantity.value
    );
  }

  navigateToOrder(): void {
    this.router.navigate(['/order']);
  }
}
