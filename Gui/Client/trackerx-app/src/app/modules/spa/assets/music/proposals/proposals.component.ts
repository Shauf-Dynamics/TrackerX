import { Component, OnInit } from "@angular/core";
import { ProposalsService } from "./proposals.service";

@Component({
    selector: 'tx-proposals',
    templateUrl: './proposals.component.html',
    styleUrls: ['./proposals.component.css'],
})
export class ProposalsComponent implements OnInit {
    
    constructor(private proposalsService: ProposalsService) {
            
    }

    ngOnInit(): void {
        
    }
}