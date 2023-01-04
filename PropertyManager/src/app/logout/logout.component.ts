import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CurrentUser } from '../shared/CurrentUser';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {
  message: string = "";
  http: HttpClient;
  router: Router;

  constructor(router: Router, http: HttpClient) {
    this.http = http;
    this.router = router;
  }

  ngOnInit(): void {
    this.message = "";
    this.http.get('/api/Logout').subscribe(
      (response) => {
        console.log("Wylogowano");
        CurrentUser.id = -1;
        CurrentUser.email = "";
        CurrentUser.userName = "";
        this.message = "Pomyślnie wylogowano";
        setTimeout(() => {
          this.router.navigate(['/login']);
        }, 500);
      },
      (error) => {
        console.log(error);
        this.message = "Wystąpił błąd";
      }

    )  
  }
 
}
