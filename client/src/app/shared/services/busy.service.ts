import { NgxSpinnerService } from 'ngx-spinner';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class BusyService {
  busyCount = 0;

  constructor(private spinnerService : NgxSpinnerService) {}


  busy(){
    this.busyCount = this.busyCount + 1;
    this.spinnerService.show();
  }

  idle(){
    this.busyCount = this.busyCount - 1;
    if(this.busyCount <= 0){
      this.busyCount = 0;
      this.spinnerService.hide();
    }
  }
  
}
