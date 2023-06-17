import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { SettingContainerComponent } from "../setting-container/setting-container.component";
import { SettingContainerModule } from "../setting-container/setting-container.module";
import { BandComponent } from "./band.component";


@NgModule({
    declarations: [
        BandComponent        
    ],
    imports: [
        CommonModule,
        FormsModule,
        SettingContainerModule
    ],
    providers: [

    ]   
})
export class BandModule { }