import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { DrinkService } from '../services/drink.services';
import { DrinkType } from '../models/drink-type';
import { OrderService } from '../services/order.services';

@Component({
  selector: 'app-coffee-machine',
  templateUrl: './coffee-machine.component.html',
  styleUrls: ['./coffee-machine.component.css']
})
export class CoffeeMachineComponent implements OnInit {
  machineForm: FormGroup;
  drinkTypes: DrinkType[];
  isWinner: boolean;

  constructor(private fb: FormBuilder, private orderService: OrderService, private drinkService: DrinkService) { }

  ngOnInit() {
    // Test
    this.drinkService.getDrinks().subscribe(t => {
      this.drinkTypes = t;
    })

    this.machineForm = this.fb.group({
      selectedDrink: ['', Validators.required],
      drinkPrice: [0],
      coinInserted: [0, Validators.required],
      coinDifference: [0]
    });
  }

  selectDrinkType(value) {
    const drinkPrice = value.Price;
    const coinInserted = this.machineForm.controls['coinInserted'] !== undefined ? this.machineForm.controls['coinInserted'].value : 0 ;
    const coinDifference = Math.round((coinInserted - drinkPrice) * 100) / 100;
    this.machineForm.controls['selectedDrink'].setValue(value.CodDrink);
    this.machineForm.controls['drinkPrice'].setValue(value.Price);
    this.machineForm.controls['coinDifference'].setValue(coinDifference);
  }

  coinInsert(event) {
    console.log(event.target.value);
    const drinkPrice = this.machineForm.controls['drinkPrice'].value;
    const coinInserted = event.target.value;
    const coinDifference = Math.round((coinInserted - drinkPrice) * 100) / 100;
    this.machineForm.controls['coinDifference'].setValue(coinDifference);
  }

  isValid(): boolean {
    return !this.machineForm.valid || this.machineForm.controls['coinDifference'].value < 0;
  }

  onSubmit() {
    this.isWinner = false;
    this.orderService.insertOrder({
      DrinkSelected: this.machineForm.controls['selectedDrink'].value,
      CoinInserted: this.machineForm.controls['coinInserted'].value
    }).subscribe({
      next: (r: any) => {
        this.isWinner = r.IsWinner;
        this.machineForm.controls['coinDifference'].setValue(r.Rest);
      }
    });
  }
}

