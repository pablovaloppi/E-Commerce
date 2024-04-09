import { Component } from '@angular/core';
import { LoginService } from 'src/app/core/services/login.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-menu-principal',
  templateUrl: './menu-principal.component.html',
  styleUrls: ['./menu-principal.component.css']
})
export class MenuPrincipalComponent {
  isLogin$!:Observable<boolean>;
  isAdmin:boolean = false;

  constructor(private loginService: LoginService) {}

    ngOnInit(): void {
        this.isLogin$ = this.loginService.isInLogin();
        this.isAdmin = this.loginService.isAdmin();
        console.log(this.loginService.getCurretUserTypeLogued());
    }

    onLogout():void{
      this.loginService.logout();
    }
}
