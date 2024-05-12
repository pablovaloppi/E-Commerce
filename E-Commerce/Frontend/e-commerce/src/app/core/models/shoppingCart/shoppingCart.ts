import { CartItem } from "../cartItem/cartItem";

export interface ShoppingCart{
    total:number;
    cartItems: CartItem[];
}