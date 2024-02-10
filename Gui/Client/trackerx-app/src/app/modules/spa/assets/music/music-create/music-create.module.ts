import { NgModule } from '@angular/core';
import { SongDetailsComponent } from './song-details/song-details.component';
import { MusicCreateCommonComponent } from './music-create-common/music-create-common.component';
import { MusicCreateService } from './music-create.service';
import { MusicContainerModule } from '../music-container/music-container.module';
import { CommonModule } from '@angular/common';
import { MusicCreateRoutingModule } from './music-create-routing.module';
import { CustomSongDetailsComponent } from './custom-music-details/custom-music-details.component';
import { FormsModule } from '@angular/forms';
import { AutoCompleteModule } from 'primeng/autocomplete';

@NgModule({
    declarations: [
        MusicCreateCommonComponent,
        SongDetailsComponent,
        CustomSongDetailsComponent
    ],
    imports: [    
        CommonModule,
        FormsModule,
        AutoCompleteModule,
        MusicContainerModule,
        MusicCreateRoutingModule
    ],
    exports: [
        MusicCreateCommonComponent
    ],
    providers: [
        MusicCreateService
    ]
})
export class MusicCreateModule {
    
 }
