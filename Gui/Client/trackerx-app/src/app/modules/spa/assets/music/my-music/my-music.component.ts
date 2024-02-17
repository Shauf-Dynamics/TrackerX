import { Component, OnInit } from "@angular/core";
import { Observable, of } from "rxjs";
import { MyMusicSearchArguments, MyMusicViewModel } from "./my-music.models";
import { MyMusicService } from "./my-music.service";

@Component({
    selector: 'tx-my-music',
    templateUrl: './my-music.component.html',
    styleUrls: ['./my-music.component.css'],
})
export class MyMusicComponent implements OnInit {
    
    public myMusicViewModel$: Observable<MyMusicViewModel[]>;

    private searchingArgs: MyMusicSearchArguments;

    constructor(private myMusicService: MyMusicService) { 
        this.searchingArgs = {
            descriptionPattern: "",
            type: "Both",
            includePublished: null
        };
    }

    ngOnInit(): void {
        this.myMusicViewModel$ = this.myMusicService.getMyMusic(this.searchingArgs);
    }
    
}