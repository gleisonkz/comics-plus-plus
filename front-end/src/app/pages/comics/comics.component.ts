import { Component, OnInit } from '@angular/core';
import { Comic } from '../../models/comic.model';
import { ComicService } from '../../services/comic.service';
import { COMICS } from '../../mock/comics.mock';

@Component({
  selector: 'cms-comics',
  templateUrl: './comics.component.html',
  styleUrls: ['./comics.component.scss'],
})
export class ComicsComponent implements OnInit {
  constructor(private comicService: ComicService) {}

  comics: Comic[];

  ngOnInit(): void {
    this.comicService.getComics().subscribe((comics) => {
      this.comics = comics;
    });
  }
}
