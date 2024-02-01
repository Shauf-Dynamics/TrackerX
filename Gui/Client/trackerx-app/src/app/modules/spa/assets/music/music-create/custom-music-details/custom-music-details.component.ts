import { Component, Input, OnInit, TemplateRef } from "@angular/core";

@Component({
    selector: 'tx-music-create-custom-music-details',
    templateUrl: './custom-music-details.component.html',
    styleUrls: ['./custom-music-details.component.css']
})
export class CustomSongDetailsComponent implements OnInit {

    @Input() commonFieldsTemplate: TemplateRef<any>;
    
    ngOnInit(): void {
        
    }    
}