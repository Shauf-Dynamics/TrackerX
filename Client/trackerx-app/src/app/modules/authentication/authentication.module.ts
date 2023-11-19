import { NgModule } from '@angular/core';
import { LoginComponent } from './login/login.component';
import { AuthenticationRoutingModule } from './authentication-routing.module';
import { AuthService } from 'src/app/providers/auth/auth.service';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RegistrationComponent } from './registration/registration.component';
import { AuthContainerComponent } from './auth-container/auth-container.component';

@NgModule({
    declarations: [
        LoginComponent,
        RegistrationComponent,
        AuthContainerComponent
    ],
    imports: [        
        CommonModule,
        AuthenticationRoutingModule,
        ReactiveFormsModule
    ],
    exports: [
        LoginComponent,
        RegistrationComponent,
        AuthContainerComponent
    ],
    providers: [
        AuthService
    ]
})
export class AuthenticationModule { }
