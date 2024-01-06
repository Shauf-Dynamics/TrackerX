import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { SpaModule } from './modules/spa/spa.module';
import { AuthenticationModule } from './modules/authentication/authentication.module';
import { Route, Router, RouterModule } from '@angular/router';
import { AuthService } from './providers/auth/auth.service';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AuthInterceptor } from './providers/interceptors/auth-Interceptor';
import { WithCredentialsInterceptor } from './providers/interceptors/with-credentials-interceptor';
import { AuthSessionStorage } from './providers/auth/auth.session';
import { CommonModule } from '@angular/common';

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        CommonModule,
        BrowserModule,
        HttpClientModule,
        FontAwesomeModule,
        AuthenticationModule,
        RouterModule,
        SpaModule
    ],
    providers: [
        AuthService,
        AuthSessionStorage,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: AuthInterceptor,
            deps: [Router, AuthService],
            multi: true
        },
        {
            provide: HTTP_INTERCEPTORS,
            useClass: WithCredentialsInterceptor,            
            multi: true
        }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
