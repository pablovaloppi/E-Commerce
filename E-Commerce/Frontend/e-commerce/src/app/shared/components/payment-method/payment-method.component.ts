import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { min } from 'rxjs';

@Component({
  selector: 'app-payment-method',
  templateUrl: './payment-method.component.html',
  styleUrls: ['./payment-method.component.css']
})
export class PaymentMethodComponent implements OnInit{

  private readonly _formBuilder = inject(FormBuilder);
  private readonly _router = inject(Router)

  isCreditCardPayment:boolean = true;
  isMercadoPagoPayment:boolean = false;
  isTrasferPayment:boolean = false;

  formPayement!:FormGroup;

  ngOnInit(): void {


    this.setFormCreditCard();
  }

  setFormCreditCard(){
    this.formPayement = this._formBuilder.group({
      'numberCreditcard': ['', [Validators.required, Validators.min(16)]],
      'safeCode': ['', [Validators.required, Validators.min(3)]],
      'month': ['', [Validators.required]],
      'year': ['', [Validators.required]],
      'titularName': ['', [Validators.required]],
      'dni': ['', [Validators.required, Validators.min(11)]],
      'cardType':['',[Validators.required]]
    })
  }

  onSubmitPayment(){
    if(this.formPayement.valid){
      //Verificar en el backend
      // Redireccionar en caso de que sea valido el pago
      this._router.navigateByUrl('/sales/confirm');
    }
  }

  onChangeStatePayment(state:number){
    switch (state) {
      case 1:
        this.isCreditCardPayment = true;
        this.isMercadoPagoPayment = false;
        this.isTrasferPayment = false;
      break;
      case 2:
        this.isCreditCardPayment = false;
        this.isMercadoPagoPayment = true;
        this.isTrasferPayment = false;
      break;
      case 3:
        this.isCreditCardPayment = false;
        this.isMercadoPagoPayment = false;
        this.isTrasferPayment = true;
      break;
    
      default:
        break;
    }
  }
}
