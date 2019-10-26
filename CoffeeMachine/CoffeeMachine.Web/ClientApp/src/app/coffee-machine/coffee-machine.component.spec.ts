import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CoffeeMachineComponent } from './coffee-machine.component';

describe('CoffeeMachineComponent', () => {
  let component: CoffeeMachineComponent;
  let fixture: ComponentFixture<CoffeeMachineComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CoffeeMachineComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CoffeeMachineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
