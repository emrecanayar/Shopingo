import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TopMenuComponent } from './layouts/top-menu/top-menu.component';
import { HeaderComponent } from './layouts/header/header.component';
import { FooterComponent } from './layouts/footer/footer.component';
import { CommonModule } from '@angular/common';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { ContactUsComponent } from './components/contact-us/contact-us.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  standalone: true,
  imports: [
    RouterModule,
    TopMenuComponent,
    HeaderComponent,
    FooterComponent,
    CommonModule,
    HomePageComponent,
    ContactUsComponent,
  ],
})
export class AppComponent {
  title = 'Shopingo';
}
