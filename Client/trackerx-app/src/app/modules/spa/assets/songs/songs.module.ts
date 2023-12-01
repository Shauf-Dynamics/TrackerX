import { NgModule } from '@angular/core';
import { SongsRoutingModule } from './songs-routing.module';
import { SongsContainerComponent } from './songs-container/songs-container.component';
import { AssetsContainerComponent } from '../assets-container/assets-container.component';
import { CommonModule } from '@angular/common';
import { SongsGlobalComponent } from './songs-search/songs-global/songs-global.component';

@NgModule({
    declarations: [
        SongsContainerComponent,
        AssetsContainerComponent,
        SongsGlobalComponent
    ],
    imports: [    
        CommonModule,  
        SongsRoutingModule,
    ],
    exports: [
        SongsContainerComponent,
        SongsGlobalComponent
    ],
    providers: [
        
    ]
})
export class SongsModule {
    
 }
