import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LatestNewComponent } from './latest-new.component';

describe('LatestNewComponent', () => {
  let component: LatestNewComponent;
  let fixture: ComponentFixture<LatestNewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LatestNewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LatestNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
