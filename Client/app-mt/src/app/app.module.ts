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
import { RecordComponent } from './record/record.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RecordAddingComponent } from './record-adding/record-adding.component';
import { ExerciseAddingComponent } from './record-adding/exercise-adding/exercise-adding.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    RecordComponent,
    DashboardComponent,
    RecordAddingComponent,
    ExerciseAddingComponent
  ],
  imports: [
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
