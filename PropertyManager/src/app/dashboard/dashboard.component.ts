import { Component, OnInit } from '@angular/core';
import { NgbAlertModule, NgbDatepickerModule, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { JsonPipe } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  startDate: NgbDateStruct = { year: 0, month: 0, day: 0 };
  endDate: NgbDateStruct = { year: 9999, month: 0, day: 0 };



  constructor() {

  }

  ngOnInit(): void {
  }

}
