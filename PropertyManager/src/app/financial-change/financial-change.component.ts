import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AddFinancialChangeDto } from '../shared/Dtos/addFinancialChangeDto';

@Component({
  selector: 'app-financial-change',
  templateUrl: './financial-change.component.html',
  styleUrls: ['./financial-change.component.css']
})
export class FinancialChangeComponent implements OnInit {

  http: HttpClient;
  newCategory: string = "";
  newType: string = "";
  newFinancialChange: AddFinancialChangeDto = new AddFinancialChangeDto();
  cat: category = { name : "" }; 
  categories: category[] = [];

  constructor(http: HttpClient) {
    this.http = http;
  }

  ngOnInit(): void {
    this.getCategories();
  }

  getCategories(): void {
    this.http.get<category[]>('/api/categories').subscribe(
      (response) => {
        console.log(response);
        this.categories = response;
      },
      (error) => {
        console.log(error)
      }
    )
  }

  onAddCategoryBtnClick() {
    this.cat.name = this.newCategory;
    this.http.post('/api/categories', this.cat).subscribe(
      (response) => {
        console.log(response);
        this.getCategories();
      },
      (error) => {
        console.log(error);
      }
    )
    this.cat.name = "";
  }

  onAddTypeBtnClick() {

  }
}
interface category{
  name: string;
}
