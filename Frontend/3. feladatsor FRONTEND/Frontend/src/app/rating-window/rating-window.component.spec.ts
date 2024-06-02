import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RatingWindowComponent } from './rating-window.component';

describe('RatingWindowComponent', () => {
  let component: RatingWindowComponent;
  let fixture: ComponentFixture<RatingWindowComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RatingWindowComponent]
    });
    fixture = TestBed.createComponent(RatingWindowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
