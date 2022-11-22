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
  fchanges: financialChange[] = [];

  constructor(http: HttpClient, router: Router) {
    this.http = http;
    this.router = router;
  }

  ngOnInit(): void {
    this.getCategories();
    this.getAssets();
    this.getFinancialChanges();
  }

  onAssetTypeChange(value: string) {
    this.newFinancialChange.assetTypeName = value;
  }
  onCategoryChange(value: string) {
    this.newFinancialChange.categoryName = value;
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

  getFinancialChanges(): void {
    this.http.get<financialChange[]>('/api/financialchanges').subscribe(
      (response) => {
        console.log(response);
        this.fchanges = response;
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

  onAddfChangeBtnClick() {
    this.http.post('/api/financialchanges', this.newFinancialChange).subscribe(
      (response) => {
        console.log(response);
        this.getFinancialChanges();
      },
      (error) => {
        console.log(error);
      }
    )
  }
}

interface category{
  name: string;
}
interface assetType {
  name: string;
}
interface financialChange {
  id: number;
  name: string;
  value: number;
  sentFrom: string;
  sentTo: string;
  categoryName: string;
  assetTypeName: string;
}
