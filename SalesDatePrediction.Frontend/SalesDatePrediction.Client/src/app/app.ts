import { Component, signal, OnInit } from '@angular/core';
import {AgGridAngular } from 'ag-grid-angular';
import { ApiService } from './services/api.service';
import { SaleDatePrediction } from './models/saledateprediction';
import { ColDef } from 'ag-grid-community';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  standalone: false,
  styleUrl: './app.css'
})
export class App implements OnInit{
  protected readonly title = signal('SalesDatePrediction.Client');

  constructor(
    private _apiService: ApiService

  ){}

  public rowData: SaleDatePrediction[] = [];
  public colDefs: ColDef[] = [
    {field: "customerName", headerName: "Customer Name"},
    {field: "lastOrderDate", headerName: "Last Order Date"},
    {field: "nextPredictedOrder", headerName: "Next Predicted Order"}
  ];

  ngOnInit(): void {
      this.populateGrid();
  }

  populateGrid(){
    this._apiService.getPredictions().subscribe(data => {
      this.rowData = data;
    })
  }
}
