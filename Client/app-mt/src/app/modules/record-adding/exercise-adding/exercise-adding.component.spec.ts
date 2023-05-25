import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExerciseAddingComponent } from './exercise-adding.component';

describe('ExerciseAddingComponent', () => {
  let component: ExerciseAddingComponent;
  let fixture: ComponentFixture<ExerciseAddingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExerciseAddingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExerciseAddingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
