import { Component, EventEmitter, OnInit, Output } from "@angular/core";

@Component({
    selector: 'tx-music-create-custom-music-details',
    templateUrl: './custom-music-details.component.html',
    styleUrls: ['./custom-music-details.component.css']
})
export class CustomSongDetailsComponent {   
    @Output() isValidatedEmitter = new EventEmitter<boolean>();

    public description: string;
    public authorName: string;

    public onDescriptionChanged(): void {
        this.validateInputs();

    }

    public onAuthorChanged(): void {
        this.validateInputs();
    }

    private validateInputs(): void {
        if(this.description && this.authorName) {
            this.isValidatedEmitter.emit(true); 
        } else {
            this.isValidatedEmitter.emit(false);
        }        
    }
}