import { Invoice } from "./invoice";
import { ShippingMethod } from "./shippingMethod";

export interface Shipping{
    name:string;
    city:string;
    zipCode:number;
    email:string;
    streetName:string;
    streetNumber:string;
    floor?:number;
    department?:string;
    areaCodeCellPhone:number;
    phoneNumber?:number;
    obesarvation:string;

    shippingMethod:ShippingMethod;
    invoice?:Invoice;
}