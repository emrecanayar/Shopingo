import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AboutUsListModel } from 'src/app/models/about-us/about-us-list-model';
import { CustomResponseDto } from 'src/app/models/base/custom-response.dto';
import { AboutUsService } from 'src/app/services/about-us/about-us.service';

@Component({
  selector: 'app-about-us',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './about-us.component.html',
  styleUrls: ['./about-us.component.css'],
})
export class AboutUsComponent implements OnInit {
  aboutUsListModel: CustomResponseDto<AboutUsListModel>;

  constructor(private aboutUsService: AboutUsService) {}

  async ngOnInit() {
    this.aboutUsListModel = await this.aboutUsService.getAboutUs();
  }
}
