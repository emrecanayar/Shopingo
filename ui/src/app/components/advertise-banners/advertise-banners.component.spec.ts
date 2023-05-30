import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdvertiseBannersComponent } from './advertise-banners.component';

describe('AdvertiseBannersComponent', () => {
  let component: AdvertiseBannersComponent;
  let fixture: ComponentFixture<AdvertiseBannersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdvertiseBannersComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdvertiseBannersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
