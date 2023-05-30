import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BottomProductsSectionComponent } from './bottom-products-section.component';

describe('BottomProductsSectionComponent', () => {
  let component: BottomProductsSectionComponent;
  let fixture: ComponentFixture<BottomProductsSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BottomProductsSectionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BottomProductsSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
