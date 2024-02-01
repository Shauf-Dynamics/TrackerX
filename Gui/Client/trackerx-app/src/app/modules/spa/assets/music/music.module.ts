import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MusicRoutingModule } from './music-routing.module';
import { MusicSearchService } from './music-global/music-global.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { Select2Module } from 'ng-select2-component';
import { MusicGlobalModule } from './music-global/music-global.module';
import { MusicCreateModule } from './music-create/music-create.module';

@NgModule({
    declarations: [
        
    ],
    imports: [    
        CommonModule,  
        FormsModule,
        ReactiveFormsModule,        
        SharedModule,
        Select2Module,
        MusicRoutingModule,
        MusicCreateModule,
        MusicGlobalModule
    ],
    exports: [

    ],
    providers: [
        MusicSearchService
    ]
})
export class MusicModule {
    
 }
