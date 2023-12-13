import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private router: Router, private toastr: ToastrService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((err) => {
        console.log(err);
        if (err) {

          if (err.status === 404) {
            if (err.error.errors) {
              throw err.error;
            }else{
              this.toastr.error(err.error.message, err.error.statusCode);
            }
          }

          if (err.status === 500) {
            let navigationExtras: NavigationExtras = {
              state: { error: err.error },
            };
            this.router.navigateByUrl('/server-error', navigationExtras);
          }

          if (err.status === 400) {
            if (err.error.errors) {
              throw err.error;
            } else {
              this.toastr.error(err.error.message, err.error.statusCode);
            }
          }

          if (err.status === 401) {
            if (err.error.errors) {
              throw err.error;
            } else {
              this.toastr.error(err.error.message, err.error.statusCode);
            }
          }
        }

        return throwError(err);
      })
    );
  }
}
