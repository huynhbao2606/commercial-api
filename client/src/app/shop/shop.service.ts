import { UserParams } from './../models/userParams';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PaginatedResult } from '../models/IPagination';
import { Observable, map } from 'rxjs';
import { IBrand } from '../models/IBrand';
import { IType } from '../models/IType';
import { IProduct } from '../models/IProduct';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = 'http://localhost:5000/api/';

  constructor(private http: HttpClient) {}

  getProducts(userParams: UserParams) {
    let params = this.getPaginationHeaders(
      userParams.pageNumber,
      userParams.pageSize
    );
    if (userParams.brandId) {
      params = params.append('brandId', userParams.brandId);
    }

    if (userParams.typeId) {
      params = params.append('typeId', userParams.typeId);
    }

    if (userParams.search) {
      params = params.append('search', userParams.search);
    }

    params = params.append('sort', userParams.sort);

    return this.getPaginatedResult<IProduct[]>(
      this.baseUrl + 'product',
      params
    );
  }

  getBrands(): Observable<IBrand[]> {
    return this.http.get<IBrand[]>(this.baseUrl + 'brand');
  }

  getTypes(): Observable<IType[]> {
    return this.http.get<IBrand[]>(this.baseUrl + 'type');
  }

  private getPaginatedResult<T>(url: string, params: HttpParams) {
    const paginatedResult: PaginatedResult<T> = new PaginatedResult<T>();

    return this.http.get<T>(url, { observe: 'response', params }).pipe(
      map((response) => {
        if (response.body) {
          paginatedResult.result = response.body;
        }

        const pagination = response.headers.get('Pagination');
        if (pagination) {
          paginatedResult.pagination = JSON.parse(pagination);
        }
        return paginatedResult;
      })
    );
  }

  private getPaginationHeaders(pageNumber: number, pageSize: number) {
    let params = new HttpParams();

    params = params.append('pageNumber', pageNumber);
    params = params.append('pageSize', pageSize);

    return params;
  }

  getProductById(id: number): Observable<IProduct> {
    return this.http.get<IProduct>(this.baseUrl + 'product/' + id);
  }
}
