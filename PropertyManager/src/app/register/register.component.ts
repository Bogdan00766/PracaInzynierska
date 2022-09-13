import { Component, OnInit } from '@angular/core';
import { RegisterDto } from '../shared/Dtos/RegisterDto';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerModel = new RegisterDto();
  constructor() { }

  ngOnInit(): void {
  }

}
