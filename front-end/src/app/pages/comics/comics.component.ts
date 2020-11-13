import { Component, OnInit } from '@angular/core';
import { Comic } from '../../models/comic.model';
import { COMICS } from '../../mock/comics.mock';

@Component({
  selector: 'cms-comics',
  templateUrl: './comics.component.html',
  styleUrls: ['./comics.component.scss'],
})
export class ComicsComponent implements OnInit {
  constructor() {}

  comics: Comic[];

  ngOnInit(): void {
    this.comics = COMICS;
  }
}
