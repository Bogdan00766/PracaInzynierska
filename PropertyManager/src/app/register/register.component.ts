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
  
  constructor(http: HttpClient) {
    this.http = http;
  }

  ngOnInit(): void {
    
  }

  onRegisterBtnClick() {
    this.registerModel2.email = "test1@test.com";
    this.registerModel2.name = "test1";
    this.registerModel2.password = "test1";
    this.registerModel2.lastName = "xd"
    const headers = new HttpHeaders()
      .set('content-type', 'application/json')
      .set('Access-Control-Allow-Origin', '*');
    //let headers = new HttpHeaders();
    this.http.post<RegisterResponse>('/api/Register', this.registerModel2, { 'headers': headers }).subscribe(response => {
      console.log(response);
      this.registerModel.email = response.eMail;
      this.registerModel.name = response.name;
    })
  }
}
interface RegisterResponse {
  id: number;
  name: string;
  lastName: string;
  eMail: string;
}
