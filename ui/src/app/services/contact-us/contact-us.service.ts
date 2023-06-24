import { environment } from "src/environments/environment";
import { HttpClientService } from "../base/httpClientService";
import { HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ContactUsCreateDto } from "src/app/models/contact-us/contact-us-create.dto";

@Injectable({
    providedIn: 'root',
  })
  export class ContactUsService {
    private readonly apiUrl = environment.apiUrl + '/contactusforms';
    constructor(private httpClient: HttpClientService) {}
  
    async create(data: ContactUsCreateDto): Promise<any> {
     
        const url = `${this.apiUrl}/CreateContactUsForm`;
        try {
            return await this.httpClient.post<any>(url, data);
        } catch (error) {
            console.error('Error creating contact us form:', error);
            throw error;
        }
    }
  }
  