import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserClaims } from 'src/app/providers/auth/auth.models';
import { AuthService } from 'src/app/providers/auth/auth.service';

@Component({
    selector: 'tx-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
    public loginForm!: FormGroup;
    public authFailed: boolean = false;
    public signedIn: boolean = false;

    constructor(
        private authService: AuthService,
        private formBuilder: FormBuilder,
        private router: Router) {
        this.authService.isLoggedIn().subscribe(
            isSignedIn => {
                this.signedIn = isSignedIn;
            });
    }

    public ngOnInit(): void {
        this.authService.isLoggedIn().subscribe((isAuthorized: boolean) => {
            if (isAuthorized) {
                this.router.navigateByUrl('app/dashboard');
            } else {
                this.authFailed = false;
                this.loginForm = this.formBuilder.group(
                    {
                        email: ['', [Validators.required]],
                        password: ['', [Validators.required]]
                    });
            }
        })
    }

    public signIn(event: any): void {
        if (!this.loginForm.valid) {
            return;
        }

        const userName = this.loginForm.get('email')?.value;
        const password = this.loginForm.get('password')?.value;
        this.authService.signIn(userName, password)
            .subscribe({
                next: (response: any) => {                
                    this.router.navigateByUrl('app/dashboard');
                },
                error: err => {
                    if (!err?.error?.isSuccess) {
                        this.authFailed = true;
                    }
                }
            });
    }
}