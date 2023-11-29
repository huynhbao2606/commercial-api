import { Component } from '@angular/core';
import {HttpClient} from '@angular/common/http'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  

  apiUrl = "http://localhost:5001/product";
  constructor(private http: HttpClient){
    
  }
  
  ngOnInit() : void {
    this.callApi();
  }
  
  callApi(){
    this.http.get(this.apiUrl).subscribe(response =>{
      console.log(response)
    })
  }
}
