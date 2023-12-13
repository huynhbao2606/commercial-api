import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TestErrorComponent } from './test-error.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import { RouterModule } from '@angular/router';
import { TestErrorRoutes } from './test-error.routing';



@NgModule({
  declarations: [
    TestErrorComponent,
    NotFoundComponent,
    ServerErrorComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(TestErrorRoutes),
  ]
})
export class TestErrorModule { }
