import { CanActivateFn, Router } from '@angular/router';
import { LoginService } from '../services/login.service';
import { inject } from '@angular/core';

export const userGuard: CanActivateFn = (route, state) => {
  const loginService = inject(LoginService);
  const router = inject(Router);

  let isLogin = loginService.isLogued();

  if(isLogin) // Si esta logueado no dejo entrar en /login
    router.navigateByUrl("/home");

  return !isLogin; 
};
