import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AddFinancialChangeDto } from '../shared/Dtos/addFinancialChangeDto';

@Component({
  selector: 'app-financial-change',
  templateUrl: './financial-change.component.html',
  styleUrls: ['./financial-change.component.css']
})
export class FinancialChangeComponent implements OnInit {

  router: Router;
  http: HttpClient;
  newCategory: string = "";
  newType: string = "";
  newFinancialChange: AddFinancialChangeDto = new AddFinancialChangeDto();
  cat: category = { name : "" }; 
  categories: category[] = [];
  assets: assetType[] = [];
  asset: assetType = { name: "" };

  constructor(http: HttpClient, router: Router) {
    this.http = http;
    this.router = router;
  }

  ngOnInit(): void {
    this.getCategories();
    this.getAssets();
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

  getAssets(): void {
    this.http.get<assetType[]>('/api/assettypes').subscribe(
      (response) => {
        console.log(response);
        this.assets = response;
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
    this.newCategory = "";
  }

  onAddTypeBtnClick() {
    this.asset.name = this.newType;
    this.http.post('/api/assettypes', this.asset).subscribe(
      (response) => {
        console.log(response);
        this.getAssets();
      },
      (error) => {
        console.log(error);
      }
    )
    this.asset.name = "";
    this.newType = "";
  }
}
interface category{
  name: string;
}
interface assetType {
  name: string;
}
