import { Component, Input } from '@angular/core';
import { IProduct } from 'src/app/models/IProduct';
import { faCartShopping } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent {
  faCartShopping = faCartShopping;

  @Input() product: IProduct | undefined;
}