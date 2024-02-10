import { Component, EventEmitter, Input, OnInit, Output, Pipe, PipeTransform, TemplateRef } from "@angular/core";
import { MusicCreateService } from "../music-create.service";
import { AlbumSuggestionResult, BandSuggestionResult } from "../music-create.models";

interface AutoCompleteCompleteEvent {
    originalEvent: Event;
    query: string;
}

@Component({
    selector: 'tx-music-create-song-details',
    templateUrl: './song-details.component.html',
    styleUrls: ['./song-details.component.css']
})
export class SongDetailsComponent {
    @Output() isValidatedEmitter = new EventEmitter<boolean>();

    public songName: string;

    public selectedBand: BandSuggestionResult | null;
    public selectedAlbum: AlbumSuggestionResult | null;
    public bandSuggestions: any[];
    public albumSuggestions: any[];

    constructor(private musicService: MusicCreateService) { }

    public onNameChanged(): void {
        this.validateInputs();
    }

    public searchBand(event: AutoCompleteCompleteEvent): void {
        this.musicService.getBandsSuggestion(event.query)
            .subscribe(result => {
                this.bandSuggestions = result;
            })
    }    

    public onBandSelect(): void{
        this.musicService.getAlbumsSuggestion(this.selectedBand!.bandId)
            .subscribe(result => {
                this.albumSuggestions = result;                
                this.isValidatedEmitter.emit(false);
            })
    }

    public onClearBandInput(): void {
        this.selectedAlbum = null;
    }

    public onAlbumChange(): void {
        if (this.selectedAlbum) {
            this.validateInputs();
        }        
    }

    private validateInputs(): void {
        if(this.songName && this.selectedAlbum && this.selectedBand) {
            this.isValidatedEmitter.emit(true); 
        } else {
            this.isValidatedEmitter.emit(false);
        }        
    }
}
