import { HttpHeaders } from '@angular/common/http';
import { HttpClientService } from './../base/httpClientService';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private readonly apiUrl = environment.apiUrl + '/categories';
 
  constructor(private httpClient: HttpClientService){};

  async getCategories(page: number, pageSize: number) {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    const url = `${this.apiUrl}/GetList?Page=${page}&PageSize=${pageSize}`;
    
    const body = {
      includeProperties: ["SubCategories"]
    };
    return await this.httpClient.post(url, body, { headers });

  }
}
