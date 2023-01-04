import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { CurrentUser } from '../shared/CurrentUser';
import { contains } from '../shared/CustomValidators';
import { LoginDto } from '../shared/Dtos/LoginDto';
import { RegisterDto } from '../shared/Dtos/RegisterDto';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerModel = new RegisterDto();
  loginModel = new LoginDto();

  router: Router;
  http: HttpClient;
  registerAlertMessage: string = "";
  loginAlertMessage: string = "";

  constructor(http: HttpClient, router: Router) {
    this.http = http;
    this.router = router;
  }

  ngOnInit(): void {
    
  }



  onRegisterBtnClick() {
    this.registerAlertMessage = "";
    
    this.http.post<RegisterResponse>('/api/Register', this.registerModel).subscribe(
      (response) => {
        console.log(response);
        this.registerAlertMessage = "Rejestracja pomyślna. Teraz możesz się zalogować."
        this.registerModel.email = "";
        this.registerModel.name = "";
        this.registerModel.password = "";
      },
      (error) => {
        console.log(error)
        if (error["error"] == "Email is already in use") {
          this.registerAlertMessage = "Istnieje już konto o podanym adresie eMail";
        }
      }
    )
  }

  onLoginBtnClick() {
    this.loginAlertMessage = "";

    this.http.post<LoginResponse>('/api/Login', this.loginModel).subscribe(
      (response) => {
        console.log(response);
        CurrentUser.id = response.id;
        CurrentUser.userName = response.name;
        CurrentUser.email = response.eMail;
        this.router.navigate(['dashboard']);
      },
      (error) => {
        console.log(error)
        if (error["error"] == "User not found") {
          this.loginAlertMessage = "Nie znaleziono użytkownika o podanym adresie email";
        }
        if (error["error"] == "Wrong password") {
          this.loginAlertMessage = "Błędne hasło";
        }
      }
    )
  }
}

interface RegisterResponse {
  id: number;
  name: string;
  eMail: string;
}

interface LoginResponse {
  id: number;
  name: string;
  eMail: string;
}
