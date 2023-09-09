import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MusclePartComponent } from './muscle-part.component';

describe('MusclePartComponent', () => {
  let component: MusclePartComponent;
  let fixture: ComponentFixture<MusclePartComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MusclePartComponent]
    });
    fixture = TestBed.createComponent(MusclePartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
