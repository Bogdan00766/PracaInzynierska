import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AddFinancialChangeDto } from '../shared/Dtos/addFinancialChangeDto';
import { AddRemoveReductionDto } from '../shared/Dtos/AddRemoveReductionDto';

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
  canDelete: boolean = false;
  reductionId1: number = 0;
  reductionId2: number = 0;
  isIncome: boolean = true;
  suggestedCategory: category = { name: "" }; 

  constructor(http: HttpClient, router: Router) {
    this.http = http;
    this.router = router;
    //this.fchanges[1].creationDate.year
  }

  ngOnInit(): void {
    this.getCategories();
    this.getAssets();
    this.getFinancialChanges();
  }

  newFcNameValueChange() {
    console.log("XD");
    if (this.newFinancialChange.name != "" && this.newFinancialChange.value != 0) {

      console.log("XD inside");
      let httpParams = new HttpParams().set('name', this.newFinancialChange.name);
      httpParams.set('value', this.newFinancialChange.value);
      let options = { params: httpParams };
      this.http.get<category>('/api/financialchanges/suggestcategory', options).subscribe(
        (response) => {
          this.suggestedCategory.name = response.name;
          console.log(response);
          console.log(this.suggestedCategory);
        },
        (error) => {
          console.log(error)
        }
      )
    }
  }

  OnDeleteButtonClick(item: any) {
    let httpParams = new HttpParams().set('id', item.id);
    let options = { params: httpParams };
    this.http.delete('/api/financialchanges/', options).subscribe(
      (response) => {
        console.log(response);
        this.getFinancialChanges();
      },
      (error) => {
        console.log(error)
      }
    )

  }
  onReduction1Change(value: any) {
    var x = this.fchanges?.find(x => x.name == value)?.id;
    if (x != undefined) {
      this.reductionId1 = x;
    }
    console.log(this.reductionId1);
  }
  onReduction2Change(value: any) {
    var x = this.fchanges?.find(x => x.name == value)?.id;
    if (x != undefined) {
      this.reductionId2 = x;
    }
    console.log(this.reductionId2);
  }
  onSetReductionBtnClick() {
    let payload = new AddRemoveReductionDto();
    payload.id1 = this.reductionId1;
    payload.id2 = this.reductionId2;
    
    this.http.post('/api/financialchanges/reductions', payload).subscribe(
      (response) => {
        console.log(response);
        this.getFinancialChanges();
      },
      (error) => {
        console.log(error)
      }
    )
  }
  onDeleteReductionBtnClick() {
    let httpParams = new HttpParams().set('id2', this.reductionId2).set('id1', this.reductionId1);
    //httpParams.append('id1', this.reductionId1);
    //httpParams.set('id2', this.reductionId2);
    let options = { params: httpParams };
    console.log(options);
    this.http.get('/api/financialchanges/reductions', options).subscribe(
      (response) => {
        console.log(response);
        this.getFinancialChanges();
      },
      (error) => {
        console.log(error)
      }
    )
  }
  onAssetTypeChange(value: string) {
    this.newFinancialChange.assetTypeName = value;
  }
  onCategoryChange(value: string) {
    this.newFinancialChange.categoryName = value;
  }
  onIncomeChange(value: string) {
    if (value == "Wydatek") this.isIncome = false;
    else this.isIncome = true;
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
    if (this.isIncome == false) this.newFinancialChange.value *= -1;
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
  reductionId: string;
  categoryName: string;
  assetTypeName: string;
  creationDate: Date;
}
interface setReduction {
  id1: number;
  id2: number;
}
