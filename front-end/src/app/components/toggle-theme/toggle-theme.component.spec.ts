import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ToggleThemeComponent } from './toggle-theme.component';

describe('ToggleThemeComponent', () => {
  let component: ToggleThemeComponent;
  let fixture: ComponentFixture<ToggleThemeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ToggleThemeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ToggleThemeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
