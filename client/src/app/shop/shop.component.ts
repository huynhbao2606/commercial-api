import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ShopService } from './shop.service';
import { faRefresh, faSearch } from '@fortawesome/free-solid-svg-icons';

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

  
  constructor(private shopService: ShopService){
    
  }
  
  ngOnInit() : void {
    this.callApi();
  }
  
  callApi(){
    this.shopService.getProducts().subscribe(
    {

      next : (response) => {
        console.log(response);
        this.products = response.data;
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
}
