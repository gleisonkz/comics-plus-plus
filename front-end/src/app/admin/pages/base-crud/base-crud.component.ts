import { Component, InjectionToken, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { BaseCrud } from '../../classes/crud.interface';

@Component({
  selector: 'cms-base-crud',
  templateUrl: './base-crud.component.html',
  styleUrls: ['./base-crud.component.scss']
})
export class BaseCrudComponent implements OnInit {
  @Input() titleName: string;
  @Input() formFilter: FormGroup;
  MATH = new InjectionToken<BaseCrud>('BaseCrud');
  constructor() {}
  // @ContentChild(CRUD , { static: true } ) crud: BaseCrud;
  // @ContentChild(MATH, { static: true }) math: BaseCrud;

  ngOnInit(): void {
    // console.log(this.crud);

    setTimeout(() => {
      // console.log(this.crud);
    }, 2000);
  }

  openDialog() {
    // this.crud.openDialog();
  }
  loadData() {
    // this.crud.loadData();
  }
}
