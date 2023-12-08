import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { SharedModule } from '../shared/shared.module';
import { ProductItemComponent } from './product-item/product-item.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { RouterModule } from '@angular/router';
import { ShopRoute } from './shop.routing';



@NgModule({
  declarations: [
    ShopComponent,
    ProductItemComponent,
    ProductDetailComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(ShopRoute)
  ],
  exports: [
    ShopComponent,
  ]
})
export class ShopModule { }