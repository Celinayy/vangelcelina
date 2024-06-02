import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdsWindowComponent } from './ads-window.component';

describe('AdsWindowComponent', () => {
  let component: AdsWindowComponent;
  let fixture: ComponentFixture<AdsWindowComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdsWindowComponent]
    });
    fixture = TestBed.createComponent(AdsWindowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
