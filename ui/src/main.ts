import {
  PreloadAllModules,
  provideRouter,
  withPreloading,
} from '@angular/router';
import { bootstrapApplication } from '@angular/platform-browser';

import { AppComponent } from './app/app.component';
import { importProvidersFrom } from '@angular/core';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { HomePageComponent } from './app/pages/home-page/home-page.component';
import { ContactUsComponent } from './app/components/contact-us/contact-us.component';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AboutUsComponent } from './app/components/about-us/about-us.component';
import { SignInComponent } from './app/components/sign-in/sign-in.component';
import { AuthInterceptor } from './app/interceptors/auth.interceptor';
import { RegisterComponent } from './app/components/register/register.component';
import { ResetPasswordComponent } from './app/components/reset-password/reset-password.component';
import { AccountDashboardComponent } from './app/components/account-dashboard/account-dashboard.component';
import { AccountOrderComponent } from './app/components/account-order/account-order.component';
import { ProfileComponent } from './app/components/profile/profile.component';

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
        { path: 'about-us', component: AboutUsComponent },
        { path: 'sign-in', component: SignInComponent },
        { path: 'register', component: RegisterComponent },
        { path: 'reset-password', component: ResetPasswordComponent },
        {
          path: 'profile',
          component: ProfileComponent,
          children: [
            {
              path: '',
              component: AccountDashboardComponent,
            },
            {
              path: 'account-dashboard',
              component: AccountDashboardComponent,
            },
            {
              path: 'account-order',
              component: AccountOrderComponent,
            },
          ],
        },
      ],
      withPreloading(PreloadAllModules)
    ),
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
  ],
});
