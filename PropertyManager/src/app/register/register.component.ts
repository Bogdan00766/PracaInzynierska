import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { contains } from '../shared/CustomValidators';
import { RegisterDto } from '../shared/Dtos/RegisterDto';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerModel = new RegisterDto();

  registerModel2 = new RegisterDto();
  http: HttpClient;
  alertMessage: string = "";
  
  constructor(http: HttpClient) {
    this.http = http;
  }

  ngOnInit(): void {
    
  }

  onRegisterBtnClick() {
    this.alertMessage = "";
    this.registerModel2.email = "test2@test.com";
    this.registerModel2.name = "test2";
    this.registerModel2.password = "test1";
    this.registerModel2.lastName = "xd"

    this.http.post<RegisterResponse>('/api/Register', this.registerModel2).subscribe(
      (response) => {
        console.log(response);
        //TODO
      },
      (error) => {
        if (error["error"] == "Email is already in use") {
          this.alertMessage = "Istnieje konto o podanym adresie eMail";
        }
      }
    )
  }
}
interface RegisterResponse {
  id: number;
  name: string;
  lastName: string;
  eMail: string;
}
