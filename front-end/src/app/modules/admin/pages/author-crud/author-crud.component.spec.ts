import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthorCrudComponent } from './author-crud.component';

describe('AuthorCrudComponent', () => {
  let component: AuthorCrudComponent;
  let fixture: ComponentFixture<AuthorCrudComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuthorCrudComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AuthorCrudComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
