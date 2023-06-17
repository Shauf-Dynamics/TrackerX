import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
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
    ],
    providers: [

    ]   
})
export class SettingContainerModule { }