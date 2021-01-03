import { Component, OnInit } from '@angular/core';
import { ComicShopItem } from '@core/models/comic-shop-item.model';
import { ComicService } from '@core/services';
import { listStagger } from '../../../shared/animations/list-stagger';

@Component({
  selector: 'cms-comics',
  templateUrl: './comics.component.html',
  styleUrls: ['./comics.component.scss'],
  animations: [listStagger]
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
