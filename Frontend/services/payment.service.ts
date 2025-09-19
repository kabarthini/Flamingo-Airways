import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PaymentRequest } from '../models/payment-request';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  private apiUrl = 'https://localhost:7137/api/payment';

  constructor(private http: HttpClient) {}

 
  validateCard(request: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/validate`, request);
  }


  pay(request: PaymentRequest): Observable<any> {
    return this.http.post(`${this.apiUrl}/pay`, request);
  }
}
