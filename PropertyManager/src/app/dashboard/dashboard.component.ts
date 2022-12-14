import { Component, OnInit } from '@angular/core';
import { NgbAlertModule, NgbDate, NgbDatepickerModule,  NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { JsonPipe } from '@angular/common';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  startDate: NgbDateStruct = { year: 2020, month: 1, day: 1 };
  endDate: NgbDateStruct;
  fcList: financialChange[] = [];
  http: HttpClient;
  router: Router;
  balance: number = 0;

  constructor(http: HttpClient, router: Router) {
    this.http = http;
    this.router = router;
    var now = new Date();
    this.endDate = { year: now.getUTCFullYear(), month: now.getUTCMonth(), day: now.getUTCDay() }
  }

  ngOnInit(): void {
    this.getFinancialChanges();
  }
  onDashboardUpdateBtnClick() {
    this.balance = 0;
    this.getFinancialChanges();
  }

  calculateBalance() {
    var sum = this.fcList.reduce((accummulator, current) => {
      //if (current.reductionId != null) return accummulator;
      return accummulator + current.value;
    }, 0);
    this.balance = Math.round(sum * 100) / 100;
  }

  getFinancialChanges(): void {
    let httpParams = new HttpParams().set('startDate', this.startDate.day + ':' + this.startDate.month + ':' + this.startDate.year);
    httpParams.set('endDate', this.endDate.day + ':' + this.endDate.month + ':' + this.endDate.year);
    let options = { params: httpParams };
    this.http.get<financialChange[]>('/api/financialchanges', options).subscribe(
      (response) => {
        console.log(response);
        this.fcList = response;
        this.calculateBalance();
      },
      (error) => {
        console.log(error)
      }
    )
  }


}

interface financialChange {
  id: number;
  name: string;
  value: number;
  sentFrom: string;
  sentTo: string;
  reductionId: string;
  categoryName: string;
  assetTypeName: string;
  creationTime: Date;
}
