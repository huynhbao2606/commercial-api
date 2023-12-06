import { Component, OnInit } from '@angular/core';
import { IPagination } from '../models/IPagination';
import { ShopService } from './shop.service';
import { faRefresh, faSearch } from '@fortawesome/free-solid-svg-icons';
import { IBrand } from '../models/IBrand';
import { IProduct } from '../models/IProduct';
import { IType } from '../models/IType';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
  faRefresh = faRefresh; faSearch = faSearch;
  products: IProduct[] = [];
  brands: IBrand[] = [];
  productTypes: IType[] = [];

  typeIdSelected: number = 0;

  constructor(private shopService: ShopService) {
  }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts(): void {
    this.shopService.getProducts(this.typeIdSelected).subscribe({
      next: (response: IPagination | null) => {
        console.log(response);
        this.products = response!.data;
      }, 
      error: (err) => console.log(err)
    });
  }

  getBrands(): void {
    this.shopService.getBrands().subscribe({
      next: (response) => this.brands = response,
      error: (err) => console.log(err)
    });
  }

  getTypes(): void {
    this.shopService.getTypes().subscribe({
      next: (response) => this.productTypes = response,
      error: (err) => console.log(err)
    });
  }

  onSelectProductType(typeId: number) {
    this.typeIdSelected = typeId;
    this.getProducts();
  }

}