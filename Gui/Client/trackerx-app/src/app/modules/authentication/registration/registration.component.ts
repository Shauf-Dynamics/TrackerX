import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/providers/auth/auth.service';

@Component({
    selector: 'tx-registration',
    templateUrl: './registration.component.html',
    styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
    public registrationForm!: FormGroup;

    constructor(
        private authService: AuthService,
        private formBuilder: FormBuilder,
        private router: Router
    ) {

    }

    public ngOnInit(): void {
        this.registrationForm = this.formBuilder.group(
            {
                email: ['', [Validators.required]],
                name: ['', [Validators.required]],
                password: ['', [Validators.required]],
                invitationCode: ['', [Validators.required]]
            });
    }

    public signUp(event: any): void {
        if (!this.registrationForm.valid) {
            return;
        }

        const email = this.registrationForm.get('email')?.value;
        const name = this.registrationForm.get('name')?.value;
        const password = this.registrationForm.get('password')?.value;
        const invitationCode = this.registrationForm.get('invitationCode')?.value;
        this.authService.registrate(email, name, password, invitationCode)
            .subscribe({
                next: (response: any) => {
                    this.authService.signIn(email, password)
                        .subscribe(_ => this.router.navigateByUrl('app/dashboard')); 
                },
                error: err => {
                    if (!err?.error?.isSuccess) {

                    }
                }
            });
    }
}