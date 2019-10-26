import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Order } from '../models/order';
import { OrderSummary } from '../models/order-history';

@Injectable({
  providedIn: 'root',
})
export class OrderService {

  constructor(private http: HttpClient) { }

  insertOrder(order: Order){
    return this.http.post('/api/order', order);
  }

  getHistory(): Observable<OrderSummary> {
    return this.http.get<OrderSummary>('/api/order');
  }
}
