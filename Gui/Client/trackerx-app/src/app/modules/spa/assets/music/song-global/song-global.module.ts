import { NgModule } from '@angular/core';
import { MusicContainerModule } from '../music-container/music-container.module';
import { CommonModule } from '@angular/common';
import { SongGlobalComponent as SongGlobalComponent } from './song-global.component';
import { SongSearchService } from './song-global.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MusicGlobalRoutingModule } from './song-global-routing.module';

@NgModule({
    declarations: [
        SongGlobalComponent
    ],
    imports: [    
        CommonModule,        
        FormsModule,
        ReactiveFormsModule,
        MusicContainerModule,
        MusicGlobalRoutingModule
    ],
    exports: [
        SongGlobalComponent
    ],
    providers: [
        SongSearchService
    ]
})
export class SongGlobalModule {
    
 }