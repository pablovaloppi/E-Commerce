export interface UserType{
    id:number;
    type:string;
}

export enum UserRole{
    ADMINISTRATOR = 1,
    MODERATOR,
    USER,
    SELLER
}