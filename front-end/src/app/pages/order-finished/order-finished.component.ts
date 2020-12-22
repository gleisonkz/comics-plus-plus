import { Component, OnInit } from '@angular/core';

@Component({
  templateUrl: './order-finished.component.html',
  styleUrls: ['./order-finished.component.scss'],
})
export class OrderFinishedComponent implements OnInit {
  constructor() {}

  orderID: number;
  rated: boolean = false;

  ngOnInit(): void {
    this.orderID = sessionStorage.orderID;
  }

  finishOrder() {
    this.rated = true;
    sessionStorage.clear();
  }
}
