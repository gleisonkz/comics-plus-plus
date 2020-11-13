import { Component, Input, OnInit } from '@angular/core';
import { Comic } from 'src/app/models/comic.model';

@Component({
  selector: 'cms-comic',
  templateUrl: './comic.component.html',
  styleUrls: ['./comic.component.scss'],
})
export class ComicComponent implements OnInit {
  constructor() {}

  @Input() comic: Comic;

  ngOnInit(): void {}
}
