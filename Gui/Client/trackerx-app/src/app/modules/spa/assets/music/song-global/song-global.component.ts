import { Component, OnInit } from '@angular/core';
import { Observable, debounceTime } from 'rxjs';
import { SearchModel, MusicModel, MusicDetailsModel } from './song-global.models';
import { SongSearchService } from './song-global.service';
import { FormControl } from '@angular/forms';

@Component({
    selector: 'tx-song-global',
    templateUrl: './song-global.component.html',
    styleUrls: ['./song-global.component.css']
})
export class SongGlobalComponent implements OnInit {

    public selectedIndex: number;    
    public searchField = new FormControl();
    
    public songs$: Observable<MusicModel[]>;
    public selected: MusicDetailsModel;

    public searchArgs: SearchModel = {
        searchText: '',
        searchBy: 'name'
    }
    
    constructor(private musicSearchService: SongSearchService) { }

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