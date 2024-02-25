import { Component, OnInit } from "@angular/core";
import { ProposalsService } from "./proposals.service";
import { Observable, debounceTime } from "rxjs";
import { ProposalSearchModel, ProposalView } from "./proposals.models";
import { FormControl } from "@angular/forms";
import { ConfirmationService, MessageService, ConfirmEventType } from 'primeng/api';

@Component({
    selector: 'tx-proposals',
    templateUrl: './proposals.component.html',
    styleUrls: ['./proposals.component.css'],
})
export class ProposalsComponent implements OnInit {
    
    public proposals$: Observable<ProposalView[]>;
    public searchField = new FormControl();    

    public searchArgs: ProposalSearchModel;

    constructor(
        private proposalsService: ProposalsService,
        private confirmationService: ConfirmationService,
        private messageService: MessageService) { 
        this.searchArgs = {
            songPattern: "",
            status: "All"    
        }
    }

    public ngOnInit(): void {
        this.proposals$ = this.proposalsService.getProposals(this.searchArgs);

        this.searchField.valueChanges
            .pipe(debounceTime(300))
            .subscribe(input => {
                this.searchArgs.songPattern = input;
                this.proposals$ = this.proposalsService.getProposals(this.searchArgs);
            });
    }

    public onStatusChange(input: any): void {
        this.searchArgs.status = input.target.value;
        this.proposals$ = this.proposalsService.getProposals(this.searchArgs);
    }

    public onRemoveClick(event: Event, proposalId: number): void {
        this.confirmationService.confirm({
            target: event.target as EventTarget,
            message: 'Are you sure that you want to remove this proposal?',
            header: 'Confirmation',            
            rejectButtonStyleClass:"p-button-text",
            accept: () => {                
                this.proposalsService.revokeProposal(proposalId)
                    .subscribe((x: any) => {
                        this.proposals$ = this.proposalsService.getProposals(this.searchArgs);
                        this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Proposal was removed.' });
                    });
            }
        });
    }

    public setStatusClass(status: string): string {
        switch (status) {
            case 'Opened': 
                return 'status-opened';
            case 'Completed': 
                return 'status-completed';
            case 'Rejected': 
                return 'status-rejected';
            case 'Pending': 
                return 'status-pending';
            default: 
                return '';
        }                
    }
}