import { Injectable } from '@angular/core';
import { CustomService } from './customService';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { UserLogin } from '../models/user/userLogin';
import { UserLogued } from '../models/user/userLogued';
import { Response } from '../models/response';
import { UserRole } from '../models/user/userType';

@Injectable({
    providedIn: 'root'
})
export class LoginService  extends CustomService{

    private _isLogin$ = new BehaviorSubject<boolean>(false);
    private _isAdmin$ = new BehaviorSubject<boolean>(false);
    private _nameLocalStore:string = 'loginInfo';

    constructor(private http:HttpClient){
        super()
    }

    login(user:UserLogin):Observable<Response>{
        return this.http.post<Response>(`${this.apiPath}/auth`,user);
    }

    logout(){
        localStorage.removeItem(this._nameLocalStore);
        this.setIsLogin(false);
    }
    setUserLogued(userLogin:UserLogued){
        localStorage.setItem(this._nameLocalStore, JSON.stringify(userLogin));
        this.setIsLogin(true);
    }
    
    isInLogin():Observable<boolean>{
        if(this.getCurrentUserLogued() != null){
            this.setIsLogin(true)
        }
        else{
            this.setIsLogin(false);
        }
        return this._isLogin$;
    }

    isLogued():boolean{
        return this.getCurrentIdLogued() != null;
    }
    
    getCurrentIdLogued():number | null {
        return this.getCurrentUserLogued() != null ? this.getCurrentUserLogued()!.id : null;
    }
    getCurrentShopCartId():number | null {
        return this.getCurrentUserLogued() != null ? this.getCurrentUserLogued()!.shoppingCartId : null;
    }
    getCurrentUserNamaLogued():string | null{ 
        return this.getCurrentUserLogued() != null ? this.getCurrentUserLogued()!.userName : null;

    }
    getCurretUserTypeLogued():number | null{
        return this.getCurrentUserLogued() != null ? this.getCurrentUserLogued()!.userTypeId : null;
    }
    getCurrentUserToken():string | null{
        return this.getCurrentUserLogued() != null ? this.getCurrentUserLogued()!.token : null;

    }
    getIsAdmin():Observable<boolean>{
        return this._isAdmin$.asObservable();
    }

    private isAdmin():boolean{
        return this.getCurretUserTypeLogued() === UserRole.ADMINISTRATOR;
    }
    isModerator():boolean{
        return this.getCurretUserTypeLogued() == UserRole.MODERATOR;
    }
    isSeller():boolean{
        return this.getCurretUserTypeLogued() == UserRole.SELLER;
    }

    private setIsLogin(state:boolean){
        this._isLogin$.next(state);
        this._isAdmin$.next(this.isAdmin());
    }
    private getCurrentUserLogued(): UserLogued | null{
        if(this.localStoreIsEmpty()){
            return null;
        }
        return JSON.parse(localStorage.getItem(this._nameLocalStore)!)
    }
    private localStoreIsEmpty(): boolean {
        return localStorage.getItem(this._nameLocalStore) == null;
    }
}
