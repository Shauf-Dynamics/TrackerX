import { NgModule } from '@angular/core';
import { MusicContainerModule } from '../music-container/music-container.module';
import { CommonModule } from '@angular/common';
import { MusicGlobalComponent } from './music-global.component';
import { MusicSearchService } from './music-global.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MusicGlobalRoutingModule } from './music-global-routing.module';

@NgModule({
    declarations: [
        MusicGlobalComponent
    ],
    imports: [    
        CommonModule,        
        FormsModule,
        ReactiveFormsModule,
        MusicContainerModule,
        MusicGlobalRoutingModule
    ],
    exports: [
        MusicGlobalComponent
    ],
    providers: [
        MusicSearchService
    ]
})
export class MusicGlobalModule {
    
 }