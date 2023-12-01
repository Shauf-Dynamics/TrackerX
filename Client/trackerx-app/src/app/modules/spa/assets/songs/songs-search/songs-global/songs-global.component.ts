import { Component, OnInit } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { SearchModel, SongModel } from '../songs-search.models';

@Component({
    selector: 'tx-songs-global',
    templateUrl: './songs-global.component.html',
    styleUrls: ['./songs-global.component.css']
})
export class SongsGlobalComponent implements OnInit {

    public songs$: Observable<SongModel[]>;
    public songs: SongModel[];

    public searchArgs: SearchModel = {
        searchText: '',
        searchBy: 'name'
    }

    public ngOnInit(): void {
        this.songs = [
            {
                id: 1,
                name: 'ds',
                album: 'ds',
                band: 'dsds',
                year: new Date('1/1/2010')
            },
            {
                id: 1,
                name: 'dsd',
                album: 'ds',
                band: 'dsds',
                year: new Date('1/1/2010')
            },
            {
                id: 1,
                name: 'dsd',
                album: 'ds',
                band: 'dsds',
                year: new Date('1/1/2010')
            },
            {
                id: 1,
                name: 'dsd',
                album: 'ds',
                band: 'dsds',
                year: new Date('1/1/2010')
            },
            {
                id: 1,
                name: 'dsd',
                album: 'ds',
                band: 'dsds',
                year: new Date('1/1/2010')
            },
            {
                id: 1,
                name: 'dsd',
                album: 'ds',
                band: 'dsds',
                year: new Date('1/1/2010')
            },
            {
                id: 1,
                name: 'dsd',
                album: 'ds',
                band: 'dsds',
                year: new Date('1/1/2010')
            },
            {
                id: 1,
                name: 'dsd',
                album: 'ds',
                band: 'dsds',
                year: new Date('1/1/2010')
            },
            {
                id: 1,
                name: 'dsd',
                album: 'ds',
                band: 'dsds',
                year: new Date('1/1/2010')
            },
            {
                id: 1,
                name: 'dsd',
                album: 'ds',
                band: 'dsds',
                year: new Date('1/1/2010')
            },
            {
                id: 1,
                name: 'dsd',
                album: 'ds',
                band: 'dsds',
                year: new Date('1/1/2010')
            },
            {
                id: 1,
                name: 'dsd',
                album: 'ds',
                band: 'dsds',
                year: new Date('1/1/2010')
            },    {
                id: 1,
                name: 'dsd',
                album: 'ds',
                band: 'dsds',
                year: new Date('1/1/2010')
            },{
                id: 1,
                name: 'dsd',
                album: 'ds',
                band: 'dsds',
                year: new Date('1/1/2010')
            },    {
                id: 1,
                name: 'dsd',
                album: 'ds',
                band: 'dsds',
                year: new Date('1/1/2010')
            },{
                id: 1,
                name: 'dsd',
                album: 'ds',
                band: 'dsds',
                year: new Date('1/1/2010')
            },    {
                id: 1,
                name: 'dsd',
                album: 'ds',
                band: 'dsds',
                year: new Date('1/1/2010')
            },{
                id: 1,
                name: 'dsd',
                album: 'ds',
                band: 'dsds',
                year: new Date('1/1/2010')
            },    {
                id: 1,
                name: 'dsd',
                album: 'ds',
                band: 'dsds',
                year: new Date('1/1/2010')
            },{
                id: 1,
                name: 'dsd',
                album: 'ds',
                band: 'dsds',
                year: new Date('1/1/2010')
            },    {
                id: 1,
                name: 'dsd',
                album: 'ds',
                band: 'dsds',
                year: new Date('1/1/2010')
            },{
                id: 1,
                name: 'dsd',
                album: 'ds',
                band: 'dsds',
                year: new Date('1/1/2010')
            },    {
                id: 1,
                name: 'dsd',
                album: 'ds',
                band: 'dsds',
                year: new Date('1/1/2010')
            },
        ]
    };

    public onNameSearchClick(): void {
        if (this.searchArgs.searchBy !== 'name') {
            this.searchArgs.searchBy = 'name';
        }
    }
    
    public onBandSearchClick(): void {
        if (this.searchArgs.searchBy !== 'band') {
            this.searchArgs.searchBy = 'band';
        }
    }
}