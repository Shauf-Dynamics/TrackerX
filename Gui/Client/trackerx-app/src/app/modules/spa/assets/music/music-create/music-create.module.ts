import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { Select2Module } from 'ng-select2-component';
import { SongDetailsComponent } from './song-details/song-details.component';
import { MusicCommonComponent } from './music-common/music-common.component';

@NgModule({
    declarations: [
        MusicCommonComponent,
        SongDetailsComponent
    ],
    imports: [    

    ],
    exports: [

    ],
    providers: [

    ]
})
export class MusicCreateModule {
    
 }
