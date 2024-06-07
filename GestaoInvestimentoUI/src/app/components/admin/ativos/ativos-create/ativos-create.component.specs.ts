import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookCreateComponent } from './ativos-create.component';

describe('CreateComponent', () => {
  let component: BookCreateComponent;
  let fixture: ComponentFixture<BookCreateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BookCreateComponent]
    });
    fixture = TestBed.createComponent(BookCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
