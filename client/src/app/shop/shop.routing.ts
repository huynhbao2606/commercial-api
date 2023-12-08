import {Routes} from "@angular/router"
import { ProductDetailComponent } from "./product-detail/product-detail.component"
import { ShopComponent } from "./shop.component"


export const ShopRoute : Routes = [
    {path : '', component: ShopComponent},
    {path : 'product/:id', component: ProductDetailComponent}
]