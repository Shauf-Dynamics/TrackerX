import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MyMusicComponent } from "./my-music.component";
import { MusicContainerModule } from "../music-container/music-container.module";
import { MyMusicRoutingModule } from "./my-music-routing.module";
import { MyMusicService } from "./my-music.service";
import { ConfirmationService, MessageService } from "primeng/api";
import { ConfirmDialogModule } from "primeng/confirmdialog";
import { ToastModule } from 'primeng/toast';

@NgModule({
    declarations: [
        MyMusicComponent
    ],
    imports: [    
        CommonModule,                
        FormsModule,
        ReactiveFormsModule,
        MyMusicRoutingModule,
        MusicContainerModule,
        ConfirmDialogModule,
        ToastModule
    ],
    exports: [
        
    ],
    providers: [
        MyMusicService,        
        ConfirmationService,
        MessageService
    ]
})
export class MyMusicModule {
    
 }