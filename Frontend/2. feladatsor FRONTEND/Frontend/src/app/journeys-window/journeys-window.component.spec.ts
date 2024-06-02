import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JourneysWindowComponent } from './journeys-window.component';

describe('JourneysWindowComponent', () => {
  let component: JourneysWindowComponent;
  let fixture: ComponentFixture<JourneysWindowComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [JourneysWindowComponent]
    });
    fixture = TestBed.createComponent(JourneysWindowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
