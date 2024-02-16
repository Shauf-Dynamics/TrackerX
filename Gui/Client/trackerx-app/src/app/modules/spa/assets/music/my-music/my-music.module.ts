import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { MyMusicComponent } from "./my-music.component";
import { MusicContainerModule } from "../music-container/music-container.module";
import { MyMusicRoutingModule } from "./my-music-routing.module";

@NgModule({
    declarations: [
        MyMusicComponent
    ],
    imports: [    
        CommonModule,        
        FormsModule,
        MyMusicRoutingModule,
        MusicContainerModule
    ],
    exports: [
        
    ],
    providers: [
        
    ]
})
export class MyMusicModule {
    
 }