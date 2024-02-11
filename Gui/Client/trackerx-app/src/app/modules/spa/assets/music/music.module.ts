import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MusicRoutingModule } from './music-routing.module';
import { SongSearchService } from './song-global/song-global.service';
import { ReactiveFormsModule } from '@angular/forms';
import { SongGlobalModule } from './song-global/song-global.module';
import { MusicCreateModule } from './music-create/music-create.module';

@NgModule({
    declarations: [
        
    ],
    imports: [    
        CommonModule,      
        ReactiveFormsModule,
        MusicRoutingModule,
        MusicCreateModule,
        SongGlobalModule
    ],
    exports: [

    ],
    providers: [
        SongSearchService
    ]
})
export class MusicModule {
    
 }
