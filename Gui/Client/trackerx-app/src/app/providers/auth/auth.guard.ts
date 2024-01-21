import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthService } from './auth.service';
import { Observable, tap } from 'rxjs';

@Injectable()
export class AuthGuard  {

    constructor(
        private authService: AuthService,
        private router: Router) { }

    canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
        return this.authService.isLoggedIn()
            .pipe(tap(isAuthorized => {
                if (!isAuthorized) {
                    this.authService.signOut();
                    this.router.navigateByUrl("/login")
                }
            }));
        ;
    }
}