import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { PoposalsRoutingModule } from "./proposals-routing";
import { ProposalsComponent } from "./proposals.component";
import { ProposalsService } from "./proposals.service";
import { MusicContainerModule } from "../music-container/music-container.module";

@NgModule({
    declarations: [
        ProposalsComponent
    ],
    imports: [    
        CommonModule,                
        FormsModule,
        ReactiveFormsModule,
        PoposalsRoutingModule,
        MusicContainerModule
    ],
    exports: [
        
    ],
    providers: [
        ProposalsService
    ]
})
export class ProposalsModule {
    
 }