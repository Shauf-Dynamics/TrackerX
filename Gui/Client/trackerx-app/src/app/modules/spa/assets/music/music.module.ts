import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AssetsContainerComponent } from '../assets-container/assets-container.component';
import { MusicContainerComponent } from './music-container/music-container.component';
import { MusicGlobalComponent } from './music-global/music-global.component';
import { MusicRoutingModule } from './music-routing.module';
import { MusicSearchService } from './music-global/music-global.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MusicCreateComponent } from './music-create/music-create.component';
import { MusicCreateService } from './music-create/music-create.service';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
    declarations: [
        AssetsContainerComponent,     
        MusicContainerComponent,
        MusicGlobalComponent,
        MusicCreateComponent
    ],
    imports: [    
        CommonModule,  
        FormsModule,
        ReactiveFormsModule,
        MusicRoutingModule,
        SharedModule
    ],
    exports: [
        MusicContainerComponent,
        MusicGlobalComponent,
        MusicCreateComponent
    ],
    providers: [
        MusicSearchService,
        MusicCreateService
    ]
})
export class MusicModule {
    
 }
