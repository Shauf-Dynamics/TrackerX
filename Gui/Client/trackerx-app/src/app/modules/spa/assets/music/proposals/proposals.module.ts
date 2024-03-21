import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { PoposalsRoutingModule } from "./proposals-routing";
import { ProposalsComponent } from "./proposals.component";
import { ProposalsService } from "./proposals.service";
import { MusicContainerModule } from "../music-container/music-container.module";
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService, MessageService } from "primeng/api";
import { ToastModule } from 'primeng/toast';

@NgModule({
    declarations: [
        ProposalsComponent
    ],
    imports: [    
        CommonModule,                
        FormsModule,
        ReactiveFormsModule,
        PoposalsRoutingModule,
        MusicContainerModule,
        ConfirmDialogModule,
        ToastModule
    ],
    exports: [
        
    ],
    providers: [
        ProposalsService,
        ConfirmationService,
        MessageService
    ]
})
export class ProposalsModule {
    
 }