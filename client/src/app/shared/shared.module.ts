import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PagingHeaderComponent } from './paging-header/paging-header.component';
import { PagerComponent } from './pager/pager.component';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent
  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      timeOut: 3000,
      extendedTimeOut: 1000,
      tapToDismiss: true,
      preventDuplicates: true
    }),
  ],
  exports: [
    FontAwesomeModule,
    PaginationModule,
    PagingHeaderComponent,
    PagerComponent,
  ]
})
export class SharedModule { }
