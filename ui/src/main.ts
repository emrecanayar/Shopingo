import {
  PreloadAllModules,
  provideRouter,
  withPreloading,
} from '@angular/router';
import { bootstrapApplication } from '@angular/platform-browser';

import { AppComponent } from './app/app.component';
import { importProvidersFrom } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { HomePageComponent } from './app/pages/home-page/home-page.component';
import { ContactUsComponent } from './app/components/contact-us/contact-us.component';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

bootstrapApplication(AppComponent, {
  providers: [
    importProvidersFrom(HttpClientModule),
    importProvidersFrom(CommonModule),
    importProvidersFrom(ToastrModule.forRoot()),
    importProvidersFrom(BrowserAnimationsModule),
    provideRouter(
      [
        { path: '', component: HomePageComponent },
        { path: 'contact-us', component: ContactUsComponent },
      ],
      withPreloading(PreloadAllModules)
    ),
  ],
});
