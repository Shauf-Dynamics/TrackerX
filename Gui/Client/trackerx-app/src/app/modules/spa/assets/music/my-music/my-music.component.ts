import { Component, OnInit } from "@angular/core";
import { Observable, debounceTime, of } from "rxjs";
import { MyMusicSearchArguments, MyMusicViewModel } from "./my-music.models";
import { MyMusicService } from "./my-music.service";
import { FormControl } from "@angular/forms";
import { ConfirmationService, MessageService } from "primeng/api";

@Component({
    selector: 'tx-my-music',
    templateUrl: './my-music.component.html',
    styleUrls: ['./my-music.component.css'],
})
export class MyMusicComponent implements OnInit {

    public myMusicViewModel$: Observable<MyMusicViewModel[]>;
    public searchField = new FormControl();

    public searchArgs: MyMusicSearchArguments;

    constructor(
        private myMusicService: MyMusicService,
        private confirmationService: ConfirmationService,
        private messageService: MessageService) {
        this.searchArgs = {
            descriptionPattern: "",
            type: "All",
            publicity: "All"
        };
    }

    public ngOnInit(): void {
        this.myMusicViewModel$ = this.myMusicService.getMyMusic(this.searchArgs);

        this.searchField.valueChanges
            .pipe(debounceTime(300))
            .subscribe(input => {
                this.searchArgs.descriptionPattern = input;
                this.myMusicViewModel$ = this.myMusicService.getMyMusic(this.searchArgs);
            });
    }

    public onMusicTypeChange(input: any): void {
        this.searchArgs.type = input.target.value;
        this.myMusicViewModel$ = this.myMusicService.getMyMusic(this.searchArgs);
    }

    public onPublicityChange(input: any): void {
        this.searchArgs.publicity = input.target.value;
        this.myMusicViewModel$ = this.myMusicService.getMyMusic(this.searchArgs);
    }

    public onOpenProposalClick(event: Event, songId: number): void {
        this.callConfirmationPopup(
            event, 
            'Are you sure that you want to open proposal for this song?',
            () => {
                this.myMusicService.openProposal(songId)
                .subscribe(_ => {                        
                    this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Proposal was opened.' });
                });
            }
        )
    }

    public onMusicRemoveClick(event: Event, musicId: number, type: string): void {
        const onRemoveSuccess = () => {
            this.myMusicViewModel$ = this.myMusicService.getMyMusic(this.searchArgs);
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Music was removed.' })
        };

        this.callConfirmationPopup(
            event, 
            'Are you sure that you want to remove this music?',
            () => {
                if (type == 'Song') {
                    this.myMusicService
                        .removeSong(musicId)
                        .subscribe(_ => onRemoveSuccess());
                } else if (type == 'Custom') {
                    this.myMusicService
                        .removeCustomMusic(musicId)
                        .subscribe(_ => onRemoveSuccess());
                }                
            }
        )
    }

    private callConfirmationPopup(event: Event, message: string, callback: () => any): void {
        this.confirmationService.confirm({
            target: event.target as EventTarget,
            message: message,            
            header: 'Confirmation',            
            rejectButtonStyleClass:"p-button-text",
            accept: callback
        });
    }
}