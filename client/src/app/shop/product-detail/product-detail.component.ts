import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/models/IProduct';
import { ShopService } from '../shop.service';
import { faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { faMinusCircle } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css'],
})
export class ProductDetailComponent implements OnInit {
  faMinusCircle = faMinusCircle;
  faPlusCircle = faPlusCircle;

  product: IProduct | undefined;

  constructor(
    private activatedRoute: ActivatedRoute,
    private shopService: ShopService
  ) {}

  ngOnInit(): void {
    this.loadProduct();
  }
  loadProduct(): void {
    const id = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    this.shopService.getProductById(id).subscribe({
      next: (product) => {
        console.log(product);
        this.product = product;
      },
      error: (err) => console.log(err),
    });
  }
}
