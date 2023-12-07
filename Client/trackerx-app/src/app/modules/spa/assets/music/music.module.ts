import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AssetsContainerComponent } from '../assets-container/assets-container.component';
import { MusicContainerComponent } from './music-container/music-container.component';
import { MusicGlobalComponent } from './music-global/music-global.component';
import { MusicRoutingModule } from './music-routing.module';

@NgModule({
    declarations: [
        AssetsContainerComponent,     
        MusicContainerComponent,
        MusicGlobalComponent
    ],
    imports: [    
        CommonModule,  
        MusicRoutingModule,
    ],
    exports: [
        MusicContainerComponent,
        MusicGlobalComponent
    ],
    providers: [
        
    ]
})
export class MusicModule {
    
 }
