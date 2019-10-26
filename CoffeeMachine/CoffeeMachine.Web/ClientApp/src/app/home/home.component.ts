import { Component, OnInit } from '@angular/core';
import { OrderService } from '../services/order.services';
import { Order } from '../models/order';
import { OrderSummary } from '../models/order-history';
import { ChartDataSets, ChartOptions } from 'chart.js';
import { Color, Label } from 'ng2-charts';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  public history: OrderSummary;
  public lineChartData: ChartDataSets[] = [
    { data: [], label: 'Sold' },
    { data: [], label: 'Orders Number' },
  ];
  public lineChartLabels: Label[] = [];
  //public lineChartOptions: (ChartOptions & { annotation: any }) = {
  //  responsive: true,
  //};
  public lineChartColors: Color[] = [
    {
      borderColor: 'black',
      backgroundColor: 'rgba(255,0,0,0.3)',
    },
  ];
  public lineChartLegend = true;
  public lineChartType = 'line';

  constructor(private orderService: OrderService) {

  }

  ngOnInit(): void {
    this.orderService.getHistory()
      .subscribe(t => {
        this.history = t;
        this.history.SummaryByDate.forEach(function (v) {
          this.lineChartLabels.push(v.Date);
          this.lineChartData[0].data.push(v.Sold);
          this.lineChartData[1].data.push(v.TotalOrders);
        }.bind(this));
      });
  }
}
