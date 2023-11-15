import { NgModule } from '@angular/core';
import { LoginComponent } from './login/login.component';
import { AuthenticationRoutingModule } from './authentication-routing.module';
import { AuthService } from 'src/app/providers/auth/auth.service';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthGuard } from 'src/app/providers/auth/auth.guard';

@NgModule({
    declarations: [
        LoginComponent
    ],
    imports: [        
        CommonModule,
        AuthenticationRoutingModule,
        ReactiveFormsModule
    ],
    exports: [
        LoginComponent
    ],
    providers: [
        AuthService
    ]
})
export class AuthenticationModule { }
