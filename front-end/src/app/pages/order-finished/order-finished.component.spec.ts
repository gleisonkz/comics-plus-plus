import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderFinishedComponent } from './order-finished.component';

describe('OrderFinishedComponent', () => {
  let component: OrderFinishedComponent;
  let fixture: ComponentFixture<OrderFinishedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OrderFinishedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderFinishedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
