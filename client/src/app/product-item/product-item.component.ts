import { Component, Input } from '@angular/core';
import { faCartShopping } from '@fortawesome/free-solid-svg-icons';
import { IProduct } from '../models/IProduct';
@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent {

  @Input() product : IProduct | undefined
  
  faCartShopping = faCartShopping;
}
