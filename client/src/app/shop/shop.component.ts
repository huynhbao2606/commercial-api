import { Pagination } from './../models/IPagination';
import { UserParams } from './../models/userParams';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ShopService } from './shop.service';
import { faRefresh, faSearch } from '@fortawesome/free-solid-svg-icons';
import { IBrand } from '../models/IBrand';
import { IProduct } from '../models/IProduct';
import { IType } from '../models/IType';
import { PaginatedResult } from '../models/IPagination';
import { HttpParams } from '@angular/common/http';
import { map } from 'rxjs';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css'],
})

export class ShopComponent implements OnInit {
  @ViewChild('search') searchElement: ElementRef | undefined;

  faRefresh = faRefresh;
  faSearch = faSearch;
  products: IProduct[] = [];
  brands: IBrand[] = [];
  productTypes: IType[] = [];

  userParams: UserParams = new UserParams();

  pagination: Pagination | undefined;

  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc' },
  ];

  constructor(private shopService: ShopService) {}

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts(): void {
    if (this.userParams) {
      this.shopService.getProducts(this.userParams).subscribe({
        next: (response) => {
          if (response.result && response.pagination) {
            this.products = response.result;
            this.pagination = response.pagination;
          }
        },
        error: (err) => console.log(err),
      });
    }
  }

  getBrands(): void {
    this.shopService.getBrands().subscribe({
      next: (response) => (this.brands = [{ id: 0, name: 'All' }, ...response]),
      error: (err) => console.log(err),
    });
  }

  getTypes(): void {
    this.shopService.getTypes().subscribe({
      next: (response) =>
        (this.productTypes = [{ id: 0, name: 'All' }, ...response]),
      error: (err) => console.log(err),
    });
  }

  onSelectProductType(typeId: number) {
    this.userParams.typeId = typeId;
    this.getProducts();
  }

  onBrandSelect(brandId: number) {
    this.userParams.brandId = brandId;
    this.getProducts();
  }

  onSortSelect(event: Event) {
    // console.log(event);
    this.userParams.sort = (<HTMLSelectElement>event.target).value;
    this.getProducts();
  }

  onPageChanged(event: any) {
    this.userParams.pageNumber = event.page;
    this.getProducts();
  }

  onSearch() {
    this.userParams.search = this.searchElement?.nativeElement.value;
    this.getProducts();
  }

  onReset() {
    this.userParams = new UserParams();
    this.getProducts();
  }
}
