import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/providers/auth/auth.service';

const ServerSideErrorMessage = "Internal server error. Please try later.";

@Component({
    selector: 'tx-registration',
    templateUrl: './registration.component.html',
    styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
    public registrationForm!: FormGroup;

    public fieldsErrorMessage: string | null = null;
    public invitationErrorMessage: string | null = null;

    constructor(
        private authService: AuthService,
        private formBuilder: FormBuilder,
        private router: Router
    ) { }

    public ngOnInit(): void {
        this.registrationForm = this.formBuilder.group({
                email: [
                    '', 
                    [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]
                ],
                name: ['', [Validators.required]],
                password: ['', [Validators.required]],
                invitationCode: ['', [Validators.required]]
            });
    }

    public signUp(): void {
        if (this.registrationForm.valid) {
            const email = this.registrationForm.get('email')?.value;
            const name = this.registrationForm.get('name')?.value;
            const password = this.registrationForm.get('password')?.value;
            const invitationCode = this.registrationForm.get('invitationCode')?.value;

            this.authService.registrate(email, name, password, invitationCode)
                .subscribe({
                    next: _ => {
                        this.authService.signIn(email, password)
                            .subscribe(_ => this.router.navigateByUrl('app/dashboard')); 
                    },
                    error: err => {
                        this.setError(Number(err.status), err.error);
                    } 
                });
        } else {
            this.markInvalidForm();
        }
    }

    private setError(status: number, message: string): void {
        if(status >= 500 || status == 0) {
            this.fieldsErrorMessage = ServerSideErrorMessage;
            this.invitationErrorMessage = null;
        } else if (message.toLocaleLowerCase().includes("invitation")) {
            this.fieldsErrorMessage = null;
            this.invitationErrorMessage = message;
        } else {
            this.fieldsErrorMessage = message;
            this.invitationErrorMessage = null;
        }
    }

    private markInvalidForm(): void {
        this.registrationForm.get('email')?.markAsTouched();
        this.registrationForm.get('name')?.markAsTouched();
        this.registrationForm.get('password')?.markAsTouched();
        this.registrationForm.get('invitationCode')?.markAsTouched();
    }
}