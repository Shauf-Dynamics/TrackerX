import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AssetsContainerComponent } from '../assets-container/assets-container.component';
import { MusicContainerComponent } from './music-container/music-container.component';
import { MusicGlobalComponent } from './music-global/music-global.component';
import { MusicRoutingModule } from './music-routing.module';
import { MusicSearchService } from './music-global/music-global.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MusicCommonComponent } from './music-create/music-common/music-common.component';
import { MusicCreateService } from './music-create/music-create.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { Select2Module } from 'ng-select2-component';
import { SongDetailsComponent } from './music-create/song-details/song-details.component';

@NgModule({
    declarations: [
        AssetsContainerComponent,     
        MusicContainerComponent,
        MusicGlobalComponent,
        MusicCommonComponent,
        SongDetailsComponent
    ],
    imports: [    
        CommonModule,  
        FormsModule,
        ReactiveFormsModule,
        MusicRoutingModule,
        SharedModule,
        Select2Module
    ],
    exports: [
        MusicContainerComponent,
        MusicGlobalComponent,
        MusicCommonComponent
    ],
    providers: [
        MusicSearchService,
        MusicCreateService
    ]
})
export class MusicModule {
    
 }
