import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnDestroy, OnInit, Output, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { QuantityButtonsService } from '../../communicationService/quantity-buttons.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-quantity-buttons',
  templateUrl: './quantity-buttons.component.html',
  styleUrls: ['./quantity-buttons.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class QuantityButtonsComponent implements OnDestroy, OnInit{
  @Input() stockAmount: number = 1;
  @Input() itemId = 0;

  @Output() changeQuantity = new EventEmitter();
  formQuantity!: FormGroup;
  isMax!:boolean;
  isMin!:boolean;

  private quantity:number = 1;

  private readonly _formBuilder = inject(FormBuilder);
  private readonly _quantityButtonService = inject(QuantityButtonsService);
  
  private _quantitySubscription?: Subscription;

  private readonly ADDITION = 'ADDITION';
  private readonly SUBSTRACTION = 'SUBSTRACTION';
  
  ngOnInit(): void {
    this._quantitySubscription = this._quantityButtonService.getQuantity(this.itemId)?.subscribe(value =>{
      this.quantity = value;    
    })

    this._quantityButtonService.getStockAmount(this.itemId)?.subscribe(value => {
      this.stockAmount = value;
    })
    this.setFormQuantity();

  }

  ngOnDestroy(): void {
    this._quantitySubscription?.unsubscribe();
  }
  
  private setFormQuantity() {
    this.formQuantity = this._formBuilder.group({
      amountSale: [this.quantity, Validators.required],
    });
  }

  onButtonMinusAdd(operation: string) {
    let valueAmount: number = parseInt(this.formQuantity.value['amountSale']);

    if (operation === this.ADDITION) {
      valueAmount++;
    } else if (operation === this.SUBSTRACTION) {
      valueAmount--;
    }

    this.setAmount(valueAmount);
  }
  private setMinMax(){
    if(this.clampValue(this.quantity) == 1){
      this.isMin = true;
      this.isMax = false;
    }
    if(this.clampValue(this.quantity) == this.stockAmount){
      this.isMin = false;
      this.isMax = true;
    }
  }
  
  private setAmount(amount:number){
    this._quantityButtonService.setQuantity(this.itemId,this.clampValue(amount));
    this.setMinMax();
     this._quantitySubscription = this._quantityButtonService.getQuantity(this.itemId)?.subscribe( value => {
      this.quantity = value;
      this.setMinMax();
      this.formQuantity.patchValue({ amountSale: this.quantity});
     })
    this.changeQuantity.emit();
  }
  
  private clampValue(value: number): number {   
    
    if (value >= this.stockAmount){
      return this.stockAmount;
    } 
    else if (value <= 1){
      return 1;
    }
    this.isMax = this.isMin = false;
    return value;
  }
}
