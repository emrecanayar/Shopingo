import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClientService } from '../base/httpClientService';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ContactInfoService {
  private readonly apiUrl = environment.apiUrl + '/contactinfos';
  constructor(private httpClient: HttpClientService) {}

  async getContactInfos(page: number, pageSize: number) {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    const url = `${this.apiUrl}/GetList?Page=${page}&PageSize=${pageSize}`;
    const body = {};

    return await this.httpClient.post(url, body, { headers });

  }
}
