import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CompanyAddressListModel } from 'src/app/models/company-address/company-address-list-model';
import { environment } from 'src/environments/environment';
import { HttpClientService } from '../base/httpClientService';
import { CustomResponseDto } from 'src/app/models/base/custom-response.dto';

@Injectable({
  providedIn: 'root',
})
export class CompanyAddressService {
  private readonly apiUrl = environment.apiUrl + '/CompanyAddresses/GetList';
  constructor(private readonly httpClient: HttpClientService) {}

  async getCompanyAddresses(): Promise<
    CustomResponseDto<CompanyAddressListModel>
  > {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    const url = this.apiUrl;
    const body = {};

    return await this.httpClient.post<
      CustomResponseDto<CompanyAddressListModel>
    >(url, body, {
      headers,
    });
  }
}
