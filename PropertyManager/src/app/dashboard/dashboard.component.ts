import { Component, OnInit } from '@angular/core';
//import { NgbAlertModule, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { JsonPipe } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  model: NgbDateStruct;

  constructor() { }

  ngOnInit(): void {
  }

}
