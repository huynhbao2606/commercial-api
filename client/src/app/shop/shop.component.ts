import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ShopService } from './shop.service';
import { faRefresh, faSearch } from '@fortawesome/free-solid-svg-icons';
import { IPagination } from '../models/IPagination';
import { IBrand } from '../models/IBrand';
import { IType } from '../models/IType';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent {
  //Icon 
  faRefresh = faRefresh; faSearch = faSearch;

  apiUrl = "http://localhost:5001/product";
  products: any[] = [];
  brands : IBrand[] = [];
  types : IType[] = [];

  typeIdSelected : number = 0

  
  constructor(private shopService: ShopService){
    
  }
  
  ngOnInit() : void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }
  
  getProducts() : void{
    this.shopService.getProducts(this.typeIdSelected).subscribe(
    {

      next : (response : IPagination |  null) => {
        console.log(response);
        this.products = response!.data;
      },
      error : (err) => console.log(err)

    } 
    // (response : IPagination) => 
    // {
    //   console.log(response);
    //   this.products = response.data;
    // }, err => {
    //   console.log(err);
    // }
    );
  }
  getBrands() : void {
    this.shopService.getBrands().subscribe({
      next : (response) => this.brands = response,
      error : (err) => console.log(err)
    });
  }

  getTypes() : void {
    this.shopService.getTypes().subscribe({
      next : (response) => this.types = response,
      error : (err) => console.log(err)

    });
  }

  onSelectProductType(typeId : number){
      this.typeIdSelected = typeId
      this.getProducts();
  }
}
