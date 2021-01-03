import { Component, OnInit } from '@angular/core';
import { fadeInOut } from '@shared/animations/fade-in-out';

@Component({
  selector: 'cms-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  animations: [fadeInOut]
})
export class HomeComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}
}
