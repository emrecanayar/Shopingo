import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClientService } from '../base/httpClientService';

@Injectable({
  providedIn: 'root',
})
export class ResetPasswordService {
  private readonly apiUrl = environment + '/auths';
  constructor(private httpClient: HttpClientService) {}

  
}
