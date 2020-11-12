import { Component, OnInit } from '@angular/core';
import { ComicItem } from '../../models/comic-item.model';

@Component({
  selector: 'cms-comics',
  templateUrl: './comics.component.html',
  styleUrls: ['./comics.component.scss'],
})
export class ComicsComponent implements OnInit {
  constructor() {}

  comics: ComicItem[];

  ngOnInit(): void {}
}
