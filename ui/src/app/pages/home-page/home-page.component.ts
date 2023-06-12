import { SupportInfoComponent } from './../../components/support-info/support-info.component';
import { Component } from '@angular/core';
import { AdvertiseBannersComponent } from 'src/app/components/advertise-banners/advertise-banners.component';
import { BottomProductsSectionComponent } from 'src/app/components/bottom-products-section/bottom-products-section.component';
import { BrandsComponent } from 'src/app/components/brands/brands.component';
import { BrowseCategoryComponent } from 'src/app/components/browse-category/browse-category.component';
import { FeaturedProductComponent } from 'src/app/components/featured-product/featured-product.component';
import { InformationComponent } from 'src/app/components/information/information.component';
import { LatestNewComponent } from 'src/app/components/latest-new/latest-new.component';
import { NewArrivalsComponent } from 'src/app/components/new-arrivals/new-arrivals.component';
import { PramotionComponent } from 'src/app/components/pramotion/pramotion.component';
import { PrimaryMenuComponent } from 'src/app/components/primary-menu/primary-menu.component';
import { SliderSectionComponent } from 'src/app/components/slider-section/slider-section.component';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'],
  standalone:true,
  imports:[PrimaryMenuComponent,SliderSectionComponent,InformationComponent,PramotionComponent,FeaturedProductComponent,NewArrivalsComponent,AdvertiseBannersComponent,BrowseCategoryComponent,SupportInfoComponent,LatestNewComponent,BrandsComponent,BottomProductsSectionComponent]
})
export class HomePageComponent {

}