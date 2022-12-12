import { Component, OnInit } from '@angular/core';
import { CurrentUser } from '../shared/CurrentUser';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  

  constructor() {
    if (CurrentUser.id < 0)
      this.isLogged = false;
    else
      this.isLogged = true;
}
  isLogged: boolean = false;
  ngOnInit(): void {
    
  }

}

