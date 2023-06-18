import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { SettingContainerModule } from "../setting-container/setting-container.module";
import { SongComponent } from "./song.component";


@NgModule({
    declarations: [
        SongComponent        
    ],
    imports: [
        CommonModule,
        FormsModule,
        SettingContainerModule
    ],
    providers: [

    ]   
})
export class SongModule { }