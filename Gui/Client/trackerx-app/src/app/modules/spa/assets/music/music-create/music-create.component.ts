import { Component, OnInit } from "@angular/core";
import { MusicType, SongModel } from "./music-create.models";

@Component({
    selector: 'tx-music-create',
    templateUrl: './music-create.component.html',
    styleUrls: ['./music-create.component.css']
})
export class MusicCreateComponent implements OnInit {
    public musicType = MusicType;
    public currentMusicType?: MusicType = undefined;    
    
    public songModel?: SongModel = undefined;

    ngOnInit(): void { }

    public onAgreeToPublishClicked(element: any) {
        if (this.songModel) {
            this.songModel.isAgreedToPublish = !this.songModel.isAgreedToPublish;        
            element.value = this.songModel.isAgreedToPublish ? "Revoke" : "I agree";          
        }
    }

    public onTypeChange(input: any): void {
        if (input.target.value === "Song") {
            this.currentMusicType = MusicType.Song;
            this.songModel = new SongModel();
        } else
        if (input.target.value === "Custom Music") {
            this.currentMusicType = MusicType.Custom;
        } else {
            this.currentMusicType = undefined;
        }
    }
}