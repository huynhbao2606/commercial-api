import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { SharedModule } from '../shared/shared.module';
import { ProductItemComponent } from './product-item/product-item.component';



@NgModule({
  declarations: [
    ShopComponent,
    ProductItemComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
  ],
  exports: [
    ShopComponent,
  ]
})
export class ShopModule { }