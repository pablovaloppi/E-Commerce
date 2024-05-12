import { Category } from "./category";
import { Image } from "./image";

export interface Product{
    id:number;
    title:string;
    description:string;
    price:number;
    amount:number;
    categoryId:number;
    category:Category;
    images:Image[]
}