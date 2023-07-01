import { LoginDto } from './../../models/sign-in/login';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClientService } from '../base/httpClientService';
import { CustomResponseDto } from 'src/app/models/base/custom-response.dto';
import { LoggedResponseDto } from 'src/app/models/sign-in/logged-response-dto';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class SignInService {
  private readonly apiUrl = environment.apiUrl + '/auths';

  constructor(private httpClient: HttpClientService) {}

  async login(
    loginDto: LoginDto
  ): Promise<CustomResponseDto<LoggedResponseDto>> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    const url = `${this.apiUrl}/Login`;
    return await this.httpClient.post(url, loginDto, { headers });
  }
}
