import { NgModule } from '@angular/core';
import { MusicContainerComponent } from './music-container.component';
import { AssetsContainerModule } from '../../assets-container/assets-container.module';

@NgModule({
    declarations: [
        MusicContainerComponent
    ],
    imports: [    
        AssetsContainerModule
    ],
    exports: [
        MusicContainerComponent
    ],
    providers: [
        
    ]
})
export class MusicContainerModule {
    
 }
