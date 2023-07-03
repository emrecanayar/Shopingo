import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClientService } from '../base/httpClientService';
import { HttpHeaders } from '@angular/common/http';
import { CountryListModel } from 'src/app/models/country/country-list-model';
import { CustomResponseDto } from 'src/app/models/base/custom-response.dto';

@Injectable({
  providedIn: 'root',
})
export class CountryService {
  private readonly apiUrl = environment.apiUrl + '/countries';

  constructor(private httpClient: HttpClientService) {}

  async getList(
    page: number,
    pageSize: number
  ): Promise<CustomResponseDto<CountryListModel>> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    const url = `${this.apiUrl}/GetList?Page=${page}&PageSize=${pageSize}`;
    const body = {};

    return await this.httpClient.post(url, body, { headers });
  }
}
