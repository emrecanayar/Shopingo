import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PramotionComponent } from './pramotion.component';

describe('PramotionComponent', () => {
  let component: PramotionComponent;
  let fixture: ComponentFixture<PramotionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PramotionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PramotionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
