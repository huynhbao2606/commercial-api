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

  Url = "http://localhost:5001/";


  constructor(private http: HttpClient) { }

  getProducts(typeId : number): Observable<IPagination>{

    let params = new HttpParams();

    if(typeId){
      params = params.append('typeId', typeId.toString());
    }

    return this.http.get<IPagination>(this.Url + 'product?pageSize=20', {observe: 'response', params});
  }

  getBrands(): Observable<IBrand[]>{
    return this.http.get<IBrand[]>( this.Url + 'product/brands');
  }

  getTypes(): Observable<IType[]>{
    return this.http.get<IType[]>( this.Url + 'product/types');
  }
}
