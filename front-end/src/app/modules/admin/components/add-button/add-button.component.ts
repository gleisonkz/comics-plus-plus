import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'cms-add-button',
  templateUrl: './add-button.component.html',
  styleUrls: ['./add-button.component.scss'],
})
export class AddButtonComponent implements OnInit {
  constructor() {}

  @Input() buttonText: string;
  @Output() clickEvent = new EventEmitter();

  ngOnInit(): void {}
}
