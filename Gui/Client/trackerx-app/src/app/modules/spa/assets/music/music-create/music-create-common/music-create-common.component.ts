import { Component, OnInit } from "@angular/core";
import { GenreModel, MusicType, SongModel } from "../music-create.models";
import { MusicCreateService } from "../music-create.service";
import { Observable, of } from "rxjs";
import { Select2Data, Select2UpdateEvent } from "ng-select2-component";

@Component({
    selector: 'tx-music-create',
    templateUrl: './music-create-common.component.html',
    styleUrls: ['./music-create-common.component.css']
})
export class MusicCreateCommonComponent implements OnInit {
    public musicCreateTabId: number = 3;

    public musicType = MusicType;
    public currentMusicType: MusicType | null = MusicType.Song;

    public songModel?: SongModel = undefined;

    private allGenres: GenreModel[];
    public mainGenres: GenreModel[];
    public subGenres: GenreModel[] | null;

    public suggestions$: Observable<string[]> = of(['1', '2']);

    constructor(private musicService: MusicCreateService) { }

    public ngOnInit(): void { 
        this.musicService.getMusicGenres()
            .subscribe(genres => {
                this.allGenres = genres;                
                this.mainGenres = genres.filter(x => x.parentGenreId === null);
            })
    }

    public onBandChanged(value: string): void {
        console.log(value);
    }

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
        } else if (input.target.value === "Custom Music") {
            this.currentMusicType = MusicType.Custom;
            // new CustomMusic();
        } else {
            this.currentMusicType = null;
        }
    }

    public onGenreChange(input: any): void {
        let value = input.target.value;        

        if (this.songModel) {
            if (value === "empty"){
                this.songModel.genreId = null;
                this.subGenres = null;
            } else {                
                let genreId = Number(value);
                this.songModel.genreId = genreId;

                if (this.allGenres.find(x => x.genreId == value)?.parentGenreId == null) {
                    let subGenres = this.allGenres.filter(x => x.parentGenreId == genreId);            
                    this.subGenres = subGenres.length > 0 ? subGenres : null;
                }
            }                    
        }        
    }    
    value2 = 'CA';
    update(key: string, event: Select2UpdateEvent<any>) {
        console.log(key.toString() + ' ' + event.value);
    }
}