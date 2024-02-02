import { Component, Input, OnInit, Pipe, PipeTransform, TemplateRef } from "@angular/core";

interface AutoCompleteCompleteEvent {
    originalEvent: Event;
    query: string;
}

@Component({
    selector: 'tx-music-create-song-details',
    templateUrl: './song-details.component.html',
    styleUrls: ['./song-details.component.css']
})
export class SongDetailsComponent implements OnInit {

    @Input() commonFieldsTemplate: TemplateRef<any>;

    items: any[] | undefined;

    selectedItem: any;

    suggestions: any[];

    search(event: AutoCompleteCompleteEvent) {
        this.suggestions = [...Array(10).keys()].map(item => event.query + '-' + item);
    }

    ngOnInit(): void {
        
    }    
}
