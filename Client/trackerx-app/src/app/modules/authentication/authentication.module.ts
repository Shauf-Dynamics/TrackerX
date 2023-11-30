import { NgModule } from '@angular/core';
import { LoginComponent } from './login/login.component';
import { AuthenticationRoutingModule } from './authentication-routing.module';
import { AuthService } from 'src/app/providers/auth/auth.service';
import { ReactiveFormsModule } from '@angular/forms';
import { RegistrationComponent } from './registration/registration.component';
import { AuthContainerComponent } from './auth-container/auth-container.component';
import { CommonModule } from '@angular/common';

@NgModule({
    declarations: [
        LoginComponent,
        RegistrationComponent,
        AuthContainerComponent
    ],
    imports: [        
        CommonModule,
        ReactiveFormsModule,
        AuthenticationRoutingModule        
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
