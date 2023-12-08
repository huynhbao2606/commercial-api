import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
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

  @ViewChild('search') searchElement : ElementRef | undefined

  faRefresh = faRefresh; faSearch = faSearch;
  products: IProduct[] = [];
  brands: IBrand[] = [];
  productTypes: IType[] = [];

  typeIdSelected: number = 0;
  brandIdSelected: number = 0;
  sortSelected = 'name';
  pageNumber = 1;
  pageSize = 3;
  totalCount = 0;
  search = '';

  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price: Low to High', value: 'priceAsc'},
    {name: 'Price: High to Low', value: 'priceDesc'}
  ];

  constructor(private shopService: ShopService) {
  }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts(): void {
    this.shopService.getProducts(this.sortSelected, this.pageNumber, this.pageSize, this.brandIdSelected, this.typeIdSelected, this.search).subscribe({
      next: (response: IPagination | null) => {
        console.log(response);
        this.products = response!.data;
        this.pageNumber = response!.pageNumber;
        this.pageSize = response!.pageSize;
        this.totalCount = response!.totalCount;
      }, 
      error: (err) => console.log(err)
    });
  }

  getBrands(): void {
    this.shopService.getBrands().subscribe({
      next: (response) => this.brands = [{id: 0, name: 'All'},...response],
      error: (err) => console.log(err)
    });
  }

  getTypes(): void {
    this.shopService.getTypes().subscribe({
      next: (response) => this.productTypes = [{id: 0, name: 'All'},...response],
      error: (err) => console.log(err)
    });
  }

  onSelectProductType(typeId: number) {
    this.typeIdSelected = typeId;
    this.getProducts();
  }

  onBrandSelect(brandId: number) {
    this.brandIdSelected = brandId;
    this.getProducts();
  }

  onSortSelect(event: Event) {
    // console.log(event);
    this.sortSelected = (<HTMLSelectElement>event.target).value;
    this.getProducts();
  }

  onPageChanged(event: any) {
    this.pageNumber = event.page;
    this.getProducts();
  }

  onSearch(){
    this.search = this.searchElement?.nativeElement.value;
    this.getProducts();
  }

  onReset(){
    this.typeIdSelected  = 0;
    this.brandIdSelected = 0;
    this.sortSelected = 'name';
    this.pageNumber = 1;
    this.pageSize = 3;
    this.totalCount = 0;
    this.search = '';
    this.getProducts();
  }
}