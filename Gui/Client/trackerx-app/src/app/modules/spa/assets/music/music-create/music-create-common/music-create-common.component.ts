import { Component, OnInit, ViewChild } from "@angular/core";
import { CustomMusicCreateModel, GenreModel, MusicBase, MusicType, SongCreateModel } from "../music-create.models";
import { MusicCreateService } from "../music-create.service";
import { SongDetailsComponent } from "../song-details/song-details.component";
import { CustomSongDetailsComponent } from "../custom-music-details/custom-music-details.component";

@Component({
    selector: 'tx-music-create',
    templateUrl: './music-create-common.component.html',
    styleUrls: ['./music-create-common.component.css']
})
export class MusicCreateCommonComponent implements OnInit {
    @ViewChild(SongDetailsComponent)
    public songDetailsComponent!: SongDetailsComponent;

    @ViewChild(CustomSongDetailsComponent)
    public customSongDetailsComponent!: CustomSongDetailsComponent;

    public musicCreateTabId: number = 3;

    public musicType = MusicType;
    public currentMusicType: MusicType | null = null;

    public createModel?: MusicBase | null;

    private allGenres: GenreModel[];
    public mainGenres: GenreModel[];
    public subGenres: GenreModel[] | null;

    public isDetailsValidated: boolean = false;

    public isAlertVisible: boolean = false;
    public isSavedSuccessfully: boolean = false;
    public alertHeader?: string;
    public alertMessage?: string;

    constructor(private musicService: MusicCreateService) { }

    public ngOnInit(): void {
        this.musicService.getMusicGenres()
            .subscribe(genres => {
                this.allGenres = genres;
                this.mainGenres = genres.filter(x => x.parentGenreId === null);
            })
    }

    public onTypeChange(input: any): void {
        if (input.target.value === "Song") {
            this.currentMusicType = MusicType.Song;
            this.createModel = new SongCreateModel();
        } else if (input.target.value === "Custom Music") {
            this.currentMusicType = MusicType.Custom;
            this.createModel = new CustomMusicCreateModel();
        } else {
            this.currentMusicType = null;
        }
    }

    public onTempoChanged(event: any): void {
        this.createModel!.tempo = Number(event.target.value);
    }

    public onIsInstrumentalChanged(event: any): void {
        this.createModel!.IsInstrumental = event.currentTarget.checked;
    }

    public onAgreeToPublishClicked(element: any) {
        if (this.createModel && this.createModel instanceof SongCreateModel) {
            this.createModel.isAgreedToPublish = !this.createModel.isAgreedToPublish;
            element.value = this.createModel.isAgreedToPublish ? "Revoke" : "I agree";
        }
    }

    public onGenreChange(input: any): void {
        let newGenreId = input.target.value;

        if (newGenreId) {
            let genreId = Number(newGenreId);
            this.createModel!.genreId = genreId;

            if (this.allGenres.find(x => x.genreId == newGenreId)?.parentGenreId == null) {
                let subGenres = this.allGenres.filter(x => x.parentGenreId == genreId);
                this.subGenres = subGenres.length > 0 ? subGenres : null;
            }
        }
    }

    public isAgreedToPublish(): boolean {
        if (this.createModel && this.createModel instanceof SongCreateModel)
            return this.createModel.isAgreedToPublish;

        return false;
    }

    public isSongDetailsValided(isValidated: boolean): void {
        this.isDetailsValidated = isValidated;
    }

    public onSaveClick(): void {
        if (this.createModel && this.createModel.genreId) {
            if (this.createModel instanceof SongCreateModel) {
                this.saveSong(this.createModel);``
            } else if (this.createModel instanceof CustomMusicCreateModel) {
                this.saveCustomMusic(this.createModel);
            }
        }
    }

    private showSavedResultDialog(): void {
        this.alertHeader = "Success";
        this.alertMessage = "Your song has been added to the library."                            

        this.isSavedSuccessfully = true;
        this.isAlertVisible = true;
    }

    private showErrorResultDialog(status: number, message: string): void {
        this.alertHeader = "Failed";

        if (status >= 500 || status == 0) {
            this.alertMessage = "Internal error. Please try later."            
        } else {
            this.alertMessage = message;
        }
        
        this.isSavedSuccessfully = false;
        this.isAlertVisible = true;
    }

    private saveSong(createModel: SongCreateModel): void {
        createModel.albumId = this.songDetailsComponent.selectedAlbum?.albumId!;
        createModel.bandId = this.songDetailsComponent.selectedBand?.bandId!;
        createModel.songName = this.songDetailsComponent.songName;

        this.musicService
            .createSong(createModel)
            .subscribe({
                next: _ => {                    
                    this.showSavedResultDialog();
                },
                error: error => {
                    this.showErrorResultDialog(Number(error.status), error.error);
                },
                complete: () => {
                    this.resetForm();
                }
            });
    }

    private saveCustomMusic(createModel: CustomMusicCreateModel) {
        createModel.author = this.customSongDetailsComponent.authorName;
        createModel.description = this.customSongDetailsComponent.description;
        this.musicService
            .createCustomMusic(createModel)
            .subscribe({
                next: _ => {
                    this.showSavedResultDialog();
                },
                error: error => {
                    this.showErrorResultDialog(Number(error.status), error.error);
                },
                complete: () => {
                    this.resetForm();
                }
            });
    }

    private resetForm(): void {
        this.currentMusicType = null;
        this.createModel = null;
    }
}