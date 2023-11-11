import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { SpaModule } from './modules/spa/spa.module';

@NgModule({
    declarations: [
      AppComponent
    ],
    imports: [
      BrowserModule,
      FontAwesomeModule,
      SpaModule
    ],
    providers: [

    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
