import { CustomResponseDto } from 'src/app/models/base/custom-response.dto';
import { CategoryService } from './../../services/category/category.service';
import { Component, OnInit } from '@angular/core';
import { CategoryListModel } from 'src/app/models/category/category-list-model';
import { ContactInfoListModel } from 'src/app/models/contact-info/contact-info-list-model';
import { ContactInfoService } from 'src/app/services/contact-info/contact-info.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css'],
})
export class FooterComponent implements OnInit {
  categories: CustomResponseDto<CategoryListModel>;
  contactInfos: CustomResponseDto<ContactInfoListModel>;

  constructor(
    private categoryService: CategoryService,
    private contactInfoService: ContactInfoService
  ) {}

  async ngOnInit() {
    this.categories = await this.getCategories();
    this.contactInfos = await this.getContactInfos();
  }

  async getCategories(): Promise<any> {
    try {
      const response = await this.categoryService.getCategories(0, 20);
      return response;
    } catch (error) {
      console.error(`Error occurred while fetching categories: ${error}`);
    }
  }

  async getContactInfos(): Promise<any> {
    try {
      const response = await this.contactInfoService.getContactInfos(0, 20);
      return response;
    } catch (error) {
      console.error(`Error occurred while fetching contactInfos: ${error}`);
    }
  }
}
