import { CartItemUpdate } from "../cartItem/cartItemUpdate";

export interface ShoppingCartUpdate{
    id: number;
    userId:number;
    total:number;
    cartItems: CartItemUpdate[];
}