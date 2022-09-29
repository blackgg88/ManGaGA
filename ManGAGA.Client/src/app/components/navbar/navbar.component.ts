import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  show = false;;
  
  constructor() { }

  ngOnInit(): void {
  }

  showSearch(){
    if (this.show===false){
      this.show = true;
      return this.show;
    }return this.show = false;
  }
}
