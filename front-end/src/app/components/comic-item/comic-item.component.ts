import { Component, Input, OnInit } from '@angular/core';
import { ComicItem } from 'src/app/models/comic-item.model';

@Component({
  selector: 'cms-comic-item',
  templateUrl: './comic-item.component.html',
  styleUrls: ['./comic-item.component.scss'],
})
export class ComicItemComponent implements OnInit {
  constructor() {}

  @Input() comic: ComicItem;

  ngOnInit(): void {}
}
