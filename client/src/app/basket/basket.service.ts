import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import {Basket, IBasket, IBasketItem } from '../models/IBasket';
import { IProduct } from '../models/IProduct';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  baseUrl = environment.apiUrl

  basket : IBasket = ({id : '', items : []});

  constructor(private http: HttpClient) { }

  addItemToBasket(item : IProduct, quantity = 1){
    var itemToAdd : IBasketItem = {
      id : item.id,
      productName : item.name,
      price : item.price,
      pictureUrl : item.pictureUrl,
      quantity : quantity,
      type : item.productType,
      brand : item.productBrand
    };

    var basket : IBasket = (!this.basket || this.basket.id === '') 
                            ? this.createNewBasket()
                            : this.basket;

    var index = basket.items.findIndex(i => i.id === itemToAdd.id);
    if( index === -1){

      basket.items.push(itemToAdd)

    }else {

      basket.items[index].quantity += quantity
      
    }

    this.setBasket(basket);

    console.log(basket)

  }

  setBasket(basket : IBasket){

    return this.http.post<IBasket>(this.baseUrl + 'basket', basket).subscribe({
      next : (response) => {
        console.log(response);
        this.basket = response;
      },
      error : (err) => console.log(err)
    });
  }

  getBasket(id : string){
    return this.http.get<IBasket>(this.baseUrl + 'basket?id=' + id)
  }


  private createNewBasket() : IBasket {

    const basket = new Basket();

    localStorage.setItem('basket_id', basket.id);

    return basket;

  }
}
