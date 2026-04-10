import { HttpInterceptorFn } from '@angular/common/http';
import { ToastService } from '../services/toast-service';
import { inject } from '@angular/core';
import { catchError } from 'rxjs';
import { Router } from '@angular/router';

export const requestErrorsInterceptor: HttpInterceptorFn = (req, next) => {
  const toast = inject(ToastService);
  const router = inject(Router);

  return next(req).pipe(
    catchError(error => {
      if (error) {
        switch (error.status) {
          case 400:
            if (error.error.errors) {
              const modelStateErrors = [];

              for (const [key, value] of Object.entries(error.error.errors)) {
                modelStateErrors.push(...(Array.isArray(value) ? value : [value]));
              }
              throw modelStateErrors.flat();
            } else {
              toast.Error(error.error+ ' ' + error.status);
            }
            break;
          case 401:
            toast.Error('Unauthorized. Please log in to access this resource.');
            break;
          case 404:
            router.navigateByUrl('/not-found');
            break;
          case 500:
            toast.Error('Internal Server Error. Please try again later.');
            break;
          default:
            toast.Error('An unexpected error occurred. Please try again later.');
        }
      }
      throw error;
    })
  );
};
