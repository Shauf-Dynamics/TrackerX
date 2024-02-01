import { NgModule } from '@angular/core';
import { AssetsContainerComponent } from './assets-container.component';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@NgModule({
    declarations: [
        AssetsContainerComponent
    ],
    imports: [    
        CommonModule,
        RouterModule
    ],
    exports: [
        AssetsContainerComponent
    ],
    providers: [
        
    ]
})
export class AssetsContainerModule {
    
 }
