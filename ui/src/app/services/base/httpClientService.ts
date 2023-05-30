import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { lastValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class HttpClientService {
  constructor(private http: HttpClient) {}

  async get<T>(url: string, options?: { headers: HttpHeaders }): Promise<T> {
    try {
      const result = this.http.get<T>(url, options).pipe(catchError(this.handleError));
      return await lastValueFrom(result);
    } catch (error) {
      console.error(error);
      throw error;  
    }
  }

  async post<T>(url: string, body: any, options?: { headers: HttpHeaders }): Promise<T> {
    try {
      const result = this.http.post<T>(url, body, options).pipe(catchError(this.handleError));
      return await lastValueFrom(result);
    } catch (error) {
      console.error(error);
      throw error;  
    }
  }
  

  async put<T>(url: string, body: any, options?: { headers: HttpHeaders }): Promise<T> {
    try {
      const result = this.http.put<T>(url, body, options).pipe(catchError(this.handleError));
      return await lastValueFrom(result);
    } catch (error) {
      console.error(error);
      throw error;  
    }
  }
  

  async delete<T>(url: string, options?: { headers: HttpHeaders }): Promise<T> {
    try {
      const result = this.http.delete<T>(url, options).pipe(catchError(this.handleError));
      return await lastValueFrom(result);
    } catch (error) {
      console.error(error);
      throw error;  
    }
  }

  private handleError(error: any): Observable<never> {
    // Error handling logic here
    console.error(error);
    return throwError(error);
  }
}