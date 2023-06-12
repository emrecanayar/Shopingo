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

bootstrapApplication(AppComponent, {
  providers: [
    importProvidersFrom(HttpClientModule),
    importProvidersFrom(CommonModule),
    provideRouter(
      [{ path: '', component: HomePageComponent }],
      withPreloading(PreloadAllModules)
    ),
  ],
});
