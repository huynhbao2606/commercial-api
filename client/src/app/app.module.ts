;
import { NgbModule } from '@ng-bootstrap/ng-bootstrap'
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { ShopModule } from './shop/shop.module';
import { SharedModule } from './shared/shared.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ProductItemComponent } from './product-item/product-item.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    ProductItemComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule,
    ShopModule,
    FontAwesomeModule,
    NgbModule
  ],

  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
