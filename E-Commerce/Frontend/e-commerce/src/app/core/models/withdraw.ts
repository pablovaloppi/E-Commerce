import { Invoice } from "./invoice";

export interface Withdraw{
    name:string;
    dni:number;

    invoice?:Invoice;
}