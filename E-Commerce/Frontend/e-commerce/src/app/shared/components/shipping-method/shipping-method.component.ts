import { AfterViewInit, Component, ElementRef, Renderer2, ViewChild, inject, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Shipping } from 'src/app/core/models/shipping';
import { ShippingMethod } from 'src/app/core/models/shippingMethod';
import { Withdraw } from 'src/app/core/models/withdraw';
import { ShippingService } from 'src/app/core/services/shipping.service';

@Component({
  selector: 'app-shipping-method',
  templateUrl: './shipping-method.component.html',
  styleUrls: ['./shipping-method.component.css']
})
export class ShippingMethodComponent implements OnInit{

  private _shippingService = inject(ShippingService);
  private _formBuilder = inject(FormBuilder);

  private _shippingMethodSelected!: ShippingMethod;

  @Input() shippingValues?: Shipping | Withdraw;

  @Output() shippingOk = new EventEmitter<Shipping | Withdraw>();

  shippingMethods: ShippingMethod[] = [
    { id:0, name: "Correo Argentino", image:"../../../../assets/images/correoargentino.jpg", price:8520},
    { id:1, name: "Andreani", image:"../../../../assets/images/andreani.jpg", price:11600},
    { id:2, name: "Ocasa", image:"../../../../assets/images/ocasa.jpg", price:13120},
  ]

  disableShinpping:boolean = false;
  disableWithdraw:boolean = false;

  expandShinpping:boolean = true;
  expandWithdraw:boolean = false;
  expandSaleCheck:boolean = false;

  formShipping!: FormGroup;
  formWithdraw!: FormGroup;
  formSaleCheck!:FormGroup;

  constructor() {
    
  }
  ngOnInit(): void {
    this.onSelectShipping(0);

    this.setShippingFormGroup();
    this.setWithdrawFormGroup();
    this.setSaleCheckFormGroup();

    this.setShippingValues();
  }

  onShipping(idForm:number){
    let shipping!:Shipping | Withdraw;

    switch (idForm) {
      case 1:
        shipping = this.getShipping(this.formShipping)
      break;

      case 2:
        shipping = this.getWithdraw(this.formWithdraw);
      break;

      case 3:
          shipping = this.getShippingOrWithdraw();
      break;

      default:
        break;
    }


    this.shippingOk.emit(shipping);
  }
  onOpenSaleCheck() {
    this.expandSaleCheck = true; 
  }

  onDisableWithdraw(){
    this.disableWithdraw = true;
    this.formWithdraw.reset();
    this.formSaleCheck.reset();
  }
  onEnableWithdraw(){
    this.disableWithdraw = false;

  }
  onDisableShipping(){
    this.disableShinpping = true;
    this._shippingService.setShippingPrice(0);  
    this.formShipping.reset();
    this.formSaleCheck.reset();
  }
  onEnableShiping(){
    this.disableShinpping = false;
  }

  onSelectShipping(id:number){
    this._shippingMethodSelected = this.shippingMethods[id];
    this._shippingService.setShippingPrice(this.shippingMethods[id].price);
  }

  private getShipping(form:FormGroup, formSaleCheck:FormGroup | null = null):Shipping{
  
    let shipping:Shipping = {
    name: form.value.name,
    city: form.value.city,
    zipCode: form.value.zipCode,
    email: form.value.email,
    streetName: form.value.streetName,
    streetNumber: form.value.streetNumber,
    floor: form.value.floor,
    department: form.value.department,
    areaCodeCellPhone: form.value.areaCodeCellPhone,
    phoneNumber: form.value.phoneNumber,
    obesarvation: form.value.ovservation,
    shippingMethod: this._shippingMethodSelected,
  }
  if( formSaleCheck){
    let resultShipping = {...shipping, invoice:{
      name: formSaleCheck.value.name,
      cuit: formSaleCheck.value.cuit
    }}

    return resultShipping;
  }

  return shipping;
}

private getWithdraw(form:FormGroup, formSaleCheck:FormGroup | null = null):Withdraw{
  let withdraw:Withdraw = {
    name: form.value.name,
    dni:form.value.dni,
  }
  if( formSaleCheck){
    let resultWithdraw = {...withdraw, invoice:{
      name: formSaleCheck.value.name,
      cuit: formSaleCheck.value.cuit
    }}

    return resultWithdraw;
  }

  return withdraw;
}

// Retornara un shipping o withdraw dependiendo si seleccione facturar desde con envio o sin
private getShippingOrWithdraw(): Shipping | Withdraw{
  if( this.formShipping.value.city){ // <-- Tiene que controlar si es valido, puse city solamente para probar si funciona
    return this.getShipping(this.formShipping, this.formSaleCheck);
  }

  return this.getWithdraw(this.formWithdraw, this.formSaleCheck);
}
  private setShippingFormGroup(){
    this.formShipping = this._formBuilder.group({
      'name' : ['', Validators.required],
      'city' : ['', Validators.required],
      'zipCode' : ['', Validators.required],
      'email' : ['', [Validators.required, Validators.email]],
      'streetName' : ['', Validators.required],
      'streetNumber' : ['', Validators.required],
      'floor' : [''],
      'department' : [''],
      'areaCodeCellPhone' : [''],
      'phoneNumber' : [''],
      'observation': [''] 
    })
    
    
  }
  
  private setShippingValues(){
    if( this.shippingValues){
      if( 'city' in this.shippingValues){
        this.formShipping.patchValue(this.shippingValues);
        this.formSaleCheck.patchValue(this.shippingValues.invoice!);
      }
      else{
        this.formWithdraw.patchValue(this.shippingValues);
          this.formSaleCheck.patchValue(this.shippingValues.invoice!);
      }
    }
    
  }

  private setWithdrawFormGroup(){
    this.formWithdraw = this._formBuilder.group({
      'name': ['', Validators.required ],
      'dni': ['',Validators.required]
    })
  }
  
  private setSaleCheckFormGroup(){
    this.formSaleCheck = this._formBuilder.group({
      'name' : [ '', Validators.required],
      'cuit' : [ '', Validators.required]
    })
  }
}
