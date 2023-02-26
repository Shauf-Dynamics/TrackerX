import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecordAddingComponent } from './record-adding.component';

describe('RecordAddingComponent', () => {
  let component: RecordAddingComponent;
  let fixture: ComponentFixture<RecordAddingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecordAddingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RecordAddingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
