import { Injectable } from '@angular/core';
import { HttpClientService } from '../base/httpClientService';
import { environment } from 'src/environments/environment';
import { UserForRegisterDto } from 'src/app/models/register/user-for-register-dto';
import { LoggedResponseDto } from 'src/app/models/sign-in/logged-response-dto';
import { CustomResponseDto } from 'src/app/models/base/custom-response.dto';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class RegisterService {
  private readonly apiUrl = environment.apiUrl + '/auths';
  constructor(private httpClient: HttpClientService) {}

  async register(
    registerDto: UserForRegisterDto
  ): Promise<CustomResponseDto<LoggedResponseDto>> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    const url = `${this.apiUrl}/register`;
    return await this.httpClient.post(url,registerDto,{headers});
  }
}
