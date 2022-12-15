import { Component, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Router } from '@angular/router';
import DatalabelsPlugin from 'chartjs-plugin-datalabels';
import { ChartConfiguration, ChartData, ChartEvent, ChartType } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  @ViewChildren(BaseChartDirective) charts: QueryList<BaseChartDirective>;

  startDate: NgbDateStruct = { year: 2020, month: 1, day: 1 };
  endDate: NgbDateStruct;
  fcList: financialChange[] = [];
  http: HttpClient;
  router: Router;
  balance: number = 0;
  graph: any;
  categories: string[] = [];
  expenseData: number[] = [];
    incomeData: number[];

  constructor(http: HttpClient, router: Router) {
    this.http = http;
    this.router = router;
    var now = new Date();
    this.endDate = { year: now.getUTCFullYear(), month: now.getUTCMonth(), day: now.getUTCDay() }
    console.log("XD");
    console.log(this.getExpenseData());
  }

  ngOnInit(): void {
    this.getFinancialChanges();
    this.getCategories();
    this.updateCharts()

  }

  onDashboardUpdateBtnClick() {
    this.balance = 0;
    this.getFinancialChanges();

    this.updateCharts();

  }

  updateCharts() {
    setTimeout(() => {
      this.charts.forEach((child, index) => {
        if (child.chart != undefined) {
          if (index == 0) child.chart.data.datasets[0].data = this.expenseData;
          if (index == 1) child.chart.data.datasets[0].data = this.incomeData;
          child.chart.update();
        }
      });
    }, 2000);
  }

  public pieChartOptions: ChartConfiguration['options'] = {
    responsive: true,
    maintainAspectRatio: false,
    plugins: {
      title: {
        text: 'Wydatki dla kategorii[zł]',
        display: true
      },
      legend: {
        display: false,
        position: 'top',
      },
      datalabels: {
        formatter: (value, ctx) => {
          if (ctx.chart.data.labels) {
            return ctx.chart.data.labels[ctx.dataIndex];
          }
        },
      },
    }
  };

  public pieChartData: ChartData<'pie', number[], string | string[]> = {
    labels: this.categories,
    datasets: [{
      data: [1],
    }]
  };
  public pieChartType: ChartType = 'pie';
  public pieChartPlugins = [DatalabelsPlugin];



  public incomeCategoryData: ChartData<'pie', number[], string | string[]> = {
    labels: this.categories,
    datasets: [{
      data: [1],
    }]
  };

  public incomeCategoryOptions: ChartConfiguration['options'] = {
    responsive: true,
    maintainAspectRatio: false,
    plugins: {
      title: {
        text: 'Przychody dla kategorii[zł]',
        display: true
      },
      legend: {
        display: false,
        position: 'top',
      },
      datalabels: {
        formatter: (value, ctx) => {
          if (ctx.chart.data.labels) {
            return ctx.chart.data.labels[ctx.dataIndex];
          }
        },
      },
    }
  };

  getCategories(): void {
    this.http.get<category[]>('/api/categories').subscribe(
      (response) => {
        console.log(response);
        response.forEach(value => { this.categories.push(value.name) });
      },
      (error) => {
        console.log(error)
      }
    )
  }

  getExpenseData(): number[] {
    let sum: number = 0;
    this.fcList.forEach((current) => {
      if (current.value < 0) sum += current.value;
    });
    let data: number[] = [];
    this.categories.forEach(cat => {
      let tmp = 0
      this.fcList.forEach((current) => {
        if (current.categoryName == cat && current.value < 0)
          tmp = tmp + current.value;
      })
      data.push(tmp/* / sum * 100*/);
    });

    return data;
  }

  getIncomeData(): number[] {
    let sum: number = 0;
    this.fcList.forEach((current) => {
      if (current.value > 0) sum += current.value;
    });
    let data: number[] = [];
    this.categories.forEach(cat => {
      let tmp = 0
      this.fcList.forEach((current) => {
        if (current.categoryName == cat && current.value > 0)
          tmp = tmp + current.value;
      })
      data.push(tmp/* / sum * 100*/);
    });

    return data;
  }
  

  calculateBalance() {
    var sum = this.fcList.reduce((accummulator, current) => {
      //if (current.reductionId != null) return accummulator;
      return accummulator + current.value;
    }, 0);
    this.balance = Math.round(sum * 100) / 100;
  }

  getFinancialChanges(): void {
    let httpParams = new HttpParams().set('startDate', this.startDate.day + ':' + this.startDate.month + ':' + this.startDate.year).set('endDate', this.endDate.day + ':' + this.endDate.month + ':' + this.endDate.year);
    let options = { params: httpParams };
    this.http.get<financialChange[]>('/api/financialchanges', options).subscribe(
      (response) => {
        console.log(response);       
        response.forEach(value => {
          if (value.reductionId != '') value.value = 0;
        })
        this.fcList = response;
        this.calculateBalance();
        this.expenseData = this.getExpenseData();
        this.incomeData = this.getIncomeData();
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

interface category {
  name: string;
}
