export class OrderSummary {
  TotalOrders: number;
  SummaryByDate: OrderSummaryByDay[];
}

export class OrderSummaryByDay {
  TotalOrders: number;
  Date: Date;
  Sold: number;
}
