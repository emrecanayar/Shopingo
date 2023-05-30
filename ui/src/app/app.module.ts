import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopMenuComponent } from './layouts/top-menu/top-menu.component';
import { PrimaryMenuComponent } from './components/primary-menu/primary-menu.component';
import { SliderSectionComponent } from './components/slider-section/slider-section.component';
import { InformationComponent } from './components/information/information.component';
import { PramotionComponent } from './components/pramotion/pramotion.component';
import { FeaturedProductComponent } from './components/featured-product/featured-product.component';
import { NewArrivalsComponent } from './components/new-arrivals/new-arrivals.component';
import { AdvertiseBannersComponent } from './components/advertise-banners/advertise-banners.component';
import { BrowseCategoryComponent } from './components/browse-category/browse-category.component';
import { SupportInfoComponent } from './components/support-info/support-info.component';
import { LatestNewComponent } from './components/latest-new/latest-new.component';
import { BrandsComponent } from './components/brands/brands.component';
import { BottomProductsSectionComponent } from './components/bottom-products-section/bottom-products-section.component';
import { HeaderComponent } from './layouts/header/header.component';
import { FooterComponent } from './layouts/footer/footer.component';
import { CategoryService } from './services/category/category.service';
import { HttpClientModule } from '@angular/common/http';
import { HomePageComponent } from './pages/home-page/home-page.component';

@NgModule({
  declarations: [
    AppComponent,
    PrimaryMenuComponent,
    SliderSectionComponent,
    InformationComponent,
    PramotionComponent,
    FeaturedProductComponent,
    NewArrivalsComponent,
    AdvertiseBannersComponent,
    BrowseCategoryComponent,
    SupportInfoComponent,
    LatestNewComponent,
    BrandsComponent,
    BottomProductsSectionComponent,
    HeaderComponent,
    FooterComponent,
    TopMenuComponent,
    HomePageComponent,
  ],
  imports: [BrowserModule, AppRoutingModule,HttpClientModule],
  providers: [CategoryService],
  bootstrap: [AppComponent],
})
export class AppModule {}
