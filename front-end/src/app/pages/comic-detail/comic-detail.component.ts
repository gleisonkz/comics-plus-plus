import { Component, Input, OnInit } from '@angular/core';
import { Comic } from 'src/app/models/comic.model';

@Component({
  selector: 'cms-comic-detail',
  templateUrl: './comic-detail.component.html',
  styleUrls: ['./comic-detail.component.scss'],
})
export class ComicDetailComponent implements OnInit {
  @Input() comic: Comic;

  constructor() {}

  ngOnInit(): void {}
}
