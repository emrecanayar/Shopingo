import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClientService } from '../base/httpClientService';
import { AboutUsListModel } from 'src/app/models/about-us/about-us-list-model';
import { CustomResponseDto } from 'src/app/models/base/custom-response.dto';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class AboutUsService {
  private readonly apiUrl = environment.apiUrl + '/AboutUs/GetList';
  constructor(private readonly httpClient: HttpClientService) {}

  async getAboutUs(): Promise<CustomResponseDto<AboutUsListModel>> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    const url = this.apiUrl;
    const body = {};

    return await this.httpClient.post<CustomResponseDto<AboutUsListModel>>(
      url,
      body,
      { headers }
    );
  }
}
