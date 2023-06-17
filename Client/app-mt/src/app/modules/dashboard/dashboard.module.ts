import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { DashboardComponent } from "./dashboard.component";

@NgModule({
    declarations: [
        DashboardComponent     
    ],
    imports: [
        CommonModule,
        FormsModule
    ],
    providers: [

    ]   
})
export class DashboardModule { }