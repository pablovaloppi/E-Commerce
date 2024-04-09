import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginService } from 'src/app/core/services/login.service';
import { UserLogin } from '../../core/models/userLogin';
import { Response } from 'src/app/core/models/response';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{

  loginForm!:FormGroup;

  constructor( 
    private loginService:LoginService,
    private formBuilder:FormBuilder, 
    private router:Router   
  ) {

  }
  ngOnInit(): void {
    this.loginForm = this.formBuilder.group(
      {
        username: ['', Validators.required],
        password: ['', Validators.required]
      }
    );

  }

  onLogin():void{
    let userLogin:UserLogin = {
      username: this.loginForm.value['username'],
      password: this.loginForm.value['password']
    }
    
    this.loginService.login(userLogin).subscribe((res:Response) => {
      this.loginService.setUserLogued(res.data);
      this.router.navigateByUrl("/home");
    })
  }
}
