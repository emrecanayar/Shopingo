import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClientService } from '../base/httpClientService';
import { CustomResponseDto } from 'src/app/models/base/custom-response.dto';
import { UserInformationDto } from 'src/app/models/user/user-information.dto';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private apiUrl = environment.apiUrl + '/users';
  constructor(private readonly httpClient: HttpClientService) {}

  public getUserInformation(): Promise<CustomResponseDto<UserInformationDto>> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    const url = `${this.apiUrl}/GetUserInformation`;
    const body = {};

    return this.httpClient.get(url, { headers });
  }

  public logOut(): void {
    localStorage.removeItem('accessToken');
    window.location.href = '/';
  }
}
