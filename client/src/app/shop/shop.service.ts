import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../models/IPagination';
import { Observable, map } from 'rxjs';
import { IBrand } from '../models/IBrand';
import { IType } from '../models/IType';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'http://localhost:5000/api/';

  constructor(private http: HttpClient) { }

  getProducts(sort: string, pageNumber: number, pageSize: number , brandId?: number, typeId?: number, search? : string): Observable<IPagination | null> {
    let params = new HttpParams();

    if (brandId) {
      params = params.append('brandId', brandId.toString());
    }

    if (typeId) {
      params = params.append('typeId', typeId.toString());
    }

    if(search) {
      params = params.append('search', search)
    }

    params = params.append('sort', sort);
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'product', {params});
  }

  getBrands(): Observable<IBrand[]> {
    return this.http.get<IBrand[]>(this.baseUrl + 'brand');
  }

  getTypes(): Observable<IType[]> {
    return this.http.get<IBrand[]>(this.baseUrl + 'type');
  }
}