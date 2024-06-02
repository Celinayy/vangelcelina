import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewAdWindowComponent } from './new-ad-window.component';

describe('NewAdWindowComponent', () => {
  let component: NewAdWindowComponent;
  let fixture: ComponentFixture<NewAdWindowComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NewAdWindowComponent]
    });
    fixture = TestBed.createComponent(NewAdWindowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
