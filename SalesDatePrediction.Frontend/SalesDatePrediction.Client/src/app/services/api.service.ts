import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../config';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { SaleDatePrediction } from '../models/saledateprediction';
import { ClientOrder } from '../models/clientorder';
import { Employee } from '../models/employee';
import { Product } from '../models/product';
import { Shipper } from '../models/shipper';
import { Order } from '../models/order';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private baseUrl = environment.default;

  private constructor(private http: HttpClient) { }

  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(`${this.baseUrl}/Employees`);
  }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.baseUrl}/Products`);
  }

  getShippers(): Observable<Shipper[]> {
    return this.http.get<Shipper[]>(`${this.baseUrl}/Shippers`);
  }

  getPredictions(): Observable<SaleDatePrediction[]> {
    return this.http.get<SaleDatePrediction[]>(`${this.baseUrl}/Predictions`).pipe(
      map(predictions => predictions.map(p => ({
        ...p,
        lastOrderDate: new Date(p.lastOrderDate),
        nextPredictedOrder: new Date(p.nextPredictedOrder)
      })))
    );
  }

  getClientOrders(clientId: number): Observable<ClientOrder[]> {
    return this.http.get<ClientOrder[]>(`${this.baseUrl}/ClientOrders/${clientId}`).pipe(
      map(orders => orders.map(o => ({
        ...o,
        requireddate: new Date(o.requireddate),
        shippeddate: o.shippeddate ? new Date(o.shippeddate) : null
      })))
    );
  }

  createOrder(order: Order): Observable<any>{
    return this.http.post(`${this.baseUrl}/Orders`, order);
  }

}
