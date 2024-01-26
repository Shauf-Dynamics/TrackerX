import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/providers/auth/auth.service';

const InvalidCredentialsErrorMessage = "Invalid credentials. Please try again.";
const ServerSideErrorMessage = "Server didn't respond. Please try later.";

@Component({
    selector: 'tx-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
    public loginForm!: FormGroup;
    public authFailed: boolean = false;
    public signedIn: boolean = false;

    public errorMessage: string;

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
                this.setForm();

            }
        })
    }

    public signIn(): void {
        if (this.loginForm.valid) {
            const userName = this.loginForm.get('email')?.value;
            const password = this.loginForm.get('password')?.value;

            this.authService.signIn(userName, password)
                .subscribe({
                    next: _ => {                
                        this.router.navigateByUrl('app/dashboard');
                    },
                    error: err => {
                        this.setForm(userName, password);
                        this.authFailed = true;
                        this.errorMessage = err?.status == "401" ?
                            InvalidCredentialsErrorMessage :
                            ServerSideErrorMessage;                        
                    }
                });
        }
    }

    private setForm(userName: string = '', password: string = ''): void {
        this.loginForm = this.formBuilder.group(
            {
                email: [userName, [Validators.required]],
                password: [password, [Validators.required]]
            });
    }
}