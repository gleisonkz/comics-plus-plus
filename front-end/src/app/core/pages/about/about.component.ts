import { Component, OnInit } from '@angular/core';
import { fadeInOut } from '../../../shared/animations/fade-in-out';

@Component({
  selector: 'cms-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss'],
  animations: [fadeInOut]
})
export class AboutComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}
}
