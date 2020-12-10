import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterDoneComponent } from './register-done.component';

describe('RegisterDoneComponent', () => {
  let component: RegisterDoneComponent;
  let fixture: ComponentFixture<RegisterDoneComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterDoneComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterDoneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
