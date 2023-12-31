import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { Router, RouterModule, Routes } from '@angular/router';


export const route : Routes = [
  {path : '', component : HomeComponent}
]
@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(route)
  ]
})
export class HomeModule { }
