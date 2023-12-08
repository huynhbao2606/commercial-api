import { Component, Input , Output, EventEmitter} from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.css']
})
export class PagerComponent {
  @Input() totalCount = 0;
  @Input() pageSize =3;

  @Output() newPageNumber = new EventEmitter<number>()

  onPagerChanged(event : any){
    
    this.newPageNumber.emit(event.page)
  }
}
