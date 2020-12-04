import { Component, OnInit } from '@angular/core';
import { Comic } from '../../models/comic.model';
import { ComicService } from '../../services/comic.service';
import { ComicShopItem } from '../../models/comic-shop-item.model';

@Component({
  selector: 'cms-comics',
  templateUrl: './comics.component.html',
  styleUrls: ['./comics.component.scss'],
})
export class ComicsComponent implements OnInit {
  constructor(private comicService: ComicService) {}

  comics: ComicShopItem[];

  ngOnInit(): void {
    this.comicService.getComicShopItems().subscribe((comics) => {
      this.comics = comics;
    });
  }
}
