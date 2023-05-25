import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { DashboardComponent } from "./dashboard.component";

@NgModule({
    declarations: [
        CommonModule,
        FormsModule
    ],
    imports: [
        DashboardComponent
    ],
    providers: [

    ]   
})
export class DashboardModule { }