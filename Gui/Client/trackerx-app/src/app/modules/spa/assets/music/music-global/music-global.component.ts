import { Component, OnInit } from '@angular/core';
import { Observable, debounceTime } from 'rxjs';
import { SearchModel, MusicModel, MusicDetailsModel } from './music-global.models';
import { MusicSearchService } from './music-global.service';
import { FormControl } from '@angular/forms';

@Component({
    selector: 'tx-music-global',
    templateUrl: './music-global.component.html',
    styleUrls: ['./music-global.component.css']
})
export class MusicGlobalComponent implements OnInit {

    public selectedIndex: number;    
    public searchField = new FormControl();
    
    public songs$: Observable<MusicModel[]>;
    public selected: MusicDetailsModel;

    public searchArgs: SearchModel = {
        searchText: '',
        searchBy: 'name'
    }
    
    constructor(private musicSearchService: MusicSearchService) { }

    public ngOnInit(): void {
        this.songs$ = this.musicSearchService.getMusicList(this.searchArgs);

        this.searchField.valueChanges
            .pipe(debounceTime(300))
            .subscribe(input=> {
                this.searchArgs.searchText = input;
                this.songs$ = this.musicSearchService.getMusicList(this.searchArgs);
        });
    };

    public onRowClicked(index: number, musicId: number): void {
        this.musicSearchService.getMusicDetails(musicId) 
            .subscribe(deatils => {
                this.selectedIndex = index;
                this.selected = deatils;
            });
    }

    public onNameSearchClick(): void {
        if (this.searchArgs.searchBy !== 'name') {
            this.searchArgs.searchBy = 'name';
            this.songs$ = this.musicSearchService.getMusicList(this.searchArgs);
        }
    }
    
    public onBandSearchClick(): void {
        if (this.searchArgs.searchBy !== 'band') {
            this.searchArgs.searchBy = 'band';
            this.songs$ = this.musicSearchService.getMusicList(this.searchArgs);
        }
    }
}