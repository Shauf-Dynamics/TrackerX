import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { SettingContainerComponent } from "./setting-container.component";


@NgModule({
    declarations: [
        SettingContainerComponent
    ],
    exports: [
        SettingContainerComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        BrowserModule,
        RouterModule
    ],
    providers: [

    ]   
})
export class SettingContainerModule { }