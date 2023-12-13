import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  constructor(private spinnerService: NgxSpinnerService) {}

  ngOnInit(): void {
    this.spinnerService.show();
    console.log('on' + this.spinnerService);

    setTimeout(() => {
      this.spinnerService.hide();
    }, 3000);
  }
}
