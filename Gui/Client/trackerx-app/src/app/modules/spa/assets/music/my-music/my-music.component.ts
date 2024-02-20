import { Component, OnInit } from "@angular/core";
import { Observable, debounceTime, of } from "rxjs";
import { MyMusicSearchArguments, MyMusicViewModel } from "./my-music.models";
import { MyMusicService } from "./my-music.service";
import { FormControl } from "@angular/forms";

@Component({
    selector: 'tx-my-music',
    templateUrl: './my-music.component.html',
    styleUrls: ['./my-music.component.css'],
})
export class MyMusicComponent implements OnInit {

    public myMusicViewModel$: Observable<MyMusicViewModel[]>;
    public searchField = new FormControl();

    public searchArgs: MyMusicSearchArguments;

    constructor(private myMusicService: MyMusicService) {
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
}