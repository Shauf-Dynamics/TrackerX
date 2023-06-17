import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RecordComponent } from './modules/record/record.component';
import { RecordAddingComponent } from './modules/record-adding/record-adding.component';
import { ExerciseAddingComponent } from './modules/record-adding/exercise-adding/exercise-adding.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './modules/header/header.component';
import { SettingModule } from './modules/setting/setting.module';

@NgModule({
  declarations: [
    AppComponent,
    RecordComponent,
    HeaderComponent,
    RecordAddingComponent,
    ExerciseAddingComponent
  ],
  imports: [
    SettingModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule,
    MatFormFieldModule,
    MatInputModule,
    MatNativeDateModule,
    MatButtonModule,
    MatDatepickerModule,
    BrowserAnimationsModule    
  ],
  providers: [MatDatepickerModule, MatNativeDateModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
