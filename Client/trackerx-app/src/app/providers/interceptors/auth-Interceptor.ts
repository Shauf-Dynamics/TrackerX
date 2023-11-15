import { Injectable } from '@angular/core';
import { HttpRequest, HttpInterceptor, HttpHandler, HttpEvent, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Observable, finalize, map, tap } from 'rxjs';
import { Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';

@Injectable({
    providedIn: 'root'
})
export class AuthInterceptor implements HttpInterceptor {
    constructor(private router: Router, private authService: AuthService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): any {
        return next.handle(req).pipe(
            tap({
                error: (error) => {
                    if (error instanceof HttpErrorResponse) {
                        if (error.status === 401) {
                            this.authService.clearSession();
                            this.router.navigateByUrl("/login")
                        }
                    }
                },
            }));
    }
}