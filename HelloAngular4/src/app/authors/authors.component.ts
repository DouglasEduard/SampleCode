import { Component, OnInit } from '@angular/core';
import { AuthorsService } from '../authors.service';

@Component({
  selector: 'authors',
  //templateUrl: './authors.component.html',
  //styleUrls: ['./authors.component.css']
  template: `
  <h2>{{title | uppercase}}</h2><br><br>
  <input (keyup.enter)="onKeyUp($event)" />
  <input #test (keyup.enter)="onKeyUp2(test.value)" /><br><br>
  <input [value]="email" (keyup.enter)="email = $event.target.value; onKeyUp3()" />
  <input [(ngModel)]="email" (keyup.enter)="onKeyUp3()" /><br><br>  
  <button class="btn btn-primary" [class.Active]="isActive" (click)="onSave($event)" >save</button><br><br> 
  {{text | summary:10}}
  `
})
export class AuthorsComponent implements OnInit {

  authors;
  title = "Authors";
  isActive = true;
  email = "me@example.com";
  text = "Lorem ipsum adipiscing neque platea nec luctus proin senectus neque, suspendisse etiam curabitur magna metus hendrerit ornare ut adipiscing, sollicitudin magna urna hendrerit sem ullamcorper scelerisque augue. a netus sapien hac vestibulum enim scelerisque ullamcorper per, himenaeos turpis viverra faucibus litora aliquet curabitur sodales nibh, eleifend a fringilla rutrum venenatis ad netus. odio pulvinar inceptos dapibus auctor sodales dapibus odio, sed convallis nec interdum urna condimentum, donec class quisque dui gravida phasellus. interdum suspendisse in pulvinar nec duis et blandit leo consectetur, sodales arcu platea porttitor tincidunt tellus duis curabitur eget aenean, commodo fusce posuere ipsum commodo pellentesque at auctor. ";

  onKeyUp($event) {
    console.log("ENTER was pressed!");
    console.log($event.target.value);
  }

  onKeyUp2(test) {
    console.log(test);
  }

  onKeyUp3() {
    console.log(this.email);
  }

  onSave($event) {
    console.log("Button was clicked!", $event);
  }

  constructor(service: AuthorsService) {
    this.authors = service.getAuthors();
  }

  ngOnInit() {
  }

}
