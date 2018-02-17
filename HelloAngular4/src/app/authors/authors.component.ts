import { Component, OnInit } from '@angular/core';
import { AuthorsService } from '../authors.service';

@Component({
  selector: 'authors',
  //templateUrl: './authors.component.html',
  //styleUrls: ['./authors.component.css']
  template: `
  <button class="btn btn-primary" [class.Active]="isActive" (click)="onSave($event)" >save</button>
  `
})
export class AuthorsComponent implements OnInit {

  authors;
  isActive=true;

  onSave($event){
    console.log("Button was clicked!", $event);
  }

  constructor(service: AuthorsService) {
      this.authors = service.getAuthors();
   }   

  ngOnInit() {
  }

}
