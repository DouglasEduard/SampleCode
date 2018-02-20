import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-title-casing',
  templateUrl: './title-casing.component.html',
  styleUrls: ['./title-casing.component.css']
})
export class TitleCasingComponent implements OnInit {

  title = "";
  titleResult = "";

  constructor() { }

  ngOnInit() {
  }

  toTitleCase(str)
  {
      let newStr = str.replace
        (/\w\S*/g, 
          function(txt){

            let word = txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase();
            word = word.toLowerCase() == "of" || word.toLowerCase() == "the" ? word.toLowerCase() : word;

            return  word;
            
          });

        return  newStr.charAt(0).toUpperCase() + newStr.slice(1);
  }

  onKeypress(){
    this.titleResult = this.toTitleCase(this.title);
  }

}
