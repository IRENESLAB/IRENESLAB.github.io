import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowDelUserComponent } from './show-del-user.component';

describe('ShowDelUserComponent', () => {
  let component: ShowDelUserComponent;
  let fixture: ComponentFixture<ShowDelUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowDelUserComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowDelUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
