import { Component, Input, OnInit } from '@angular/core';
import { Comic } from 'src/app/models/comic.model';
import { ShoppingCartService } from 'src/app/services/shopping-cart.service';

@Component({
  selector: 'cms-comic',
  templateUrl: './comic.component.html',
  styleUrls: ['./comic.component.scss'],
})
export class ComicComponent implements OnInit {
  constructor(private shoppingCartService: ShoppingCartService) {}

  @Input() comic: Comic;

  ngOnInit(): void {}

  addToCart(comic: Comic) {
    this.shoppingCartService.addItem(comic);
  }
}
