import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'cms-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.scss'],
})
export class RatingComponent implements OnInit {
  rates: number[] = [1, 2, 3, 4, 5];
  rate: number = 0;
  temporaryRate = 0;
  isRated: boolean = false;
  @Output() rated = new EventEmitter<number>();

  ngOnInit(): void {}

  setRate(currentRate: number): void {
    if (this.isRated) {
      return;
    }
    this.rate = currentRate;
    this.temporaryRate = undefined;
    this.rated.emit(this.rate);
    this.isRated = true;
  }
  setTemporaryRate(currentRate: number): void {
    if (this.isRated) {
      return;
    }
    this.temporaryRate === undefined && (this.temporaryRate = this.rate);
    this.rate = currentRate;
  }
  clearTemporaryRate(): void {
    this.temporaryRate !== undefined &&
      (this.rate = this.temporaryRate) &&
      (this.temporaryRate = undefined);
  }
}
