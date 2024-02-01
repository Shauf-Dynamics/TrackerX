import { Component, Input, OnInit, TemplateRef } from "@angular/core";

@Component({
    selector: 'tx-music-create-song-details',
    templateUrl: './song-details.component.html',
    styleUrls: ['./song-details.component.css']
})
export class SongDetailsComponent implements OnInit {

    @Input() commonFieldsTemplate: TemplateRef<any>;
    
    ngOnInit(): void {
        
    }    
}