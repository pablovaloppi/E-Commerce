import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpHeaders
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { LoginService } from '../services/login.service';

@Injectable()
export class PetitionInterceptor implements HttpInterceptor {

  constructor(private loginService:LoginService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.loginService.getCurrentUserToken()}`,
    });
    const headerClone = request.clone({headers});
    return next.handle(headerClone).pipe(
      catchError(error => {
         console.log(error);

        return throwError(error);
      })
    );
  }
}
