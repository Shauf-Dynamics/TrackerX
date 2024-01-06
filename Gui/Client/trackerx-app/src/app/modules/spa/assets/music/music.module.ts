import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AssetsContainerComponent } from '../assets-container/assets-container.component';
import { MusicContainerComponent } from './music-container/music-container.component';
import { MusicGlobalComponent } from './music-global/music-global.component';
import { MusicRoutingModule } from './music-routing.module';
import { MusicSearchService } from './music-global/music-global.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MusicCreateComponent } from './music-create/music-create.component';

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
    ],
    exports: [
        MusicContainerComponent,
        MusicGlobalComponent,
        MusicCreateComponent
    ],
    providers: [
        MusicSearchService
    ]
})
export class MusicModule {
    
 }
