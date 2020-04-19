import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ErrorInterceptorService implements  HttpInterceptor {

  constructor(private toastrService: ToastrService) { }
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      retry(1),
      catchError((err) => {
        if (err.status === 401) {
          //refresh token or navigate to login
          alert("401")
        }
        else if (err.status === 404) {
          //some custom message
          alert("404")
        }
        else if (err.status === 400) {
          //some message
          alert("400")
        }
        else {
          //global message for error
        }
        return throwError(err)
      })
    )
  }
}
