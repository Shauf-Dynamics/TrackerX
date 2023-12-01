import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { SongModel } from '../songs-search.models';

@Component({
    selector: 'tx-songs-global',
    templateUrl: './songs-global.component.html',
    styleUrls: ['./songs-global.component.css']
})
export class SongsGlobalComponent implements OnInit {

    public songs$: Observable<SongModel[]>;
    public songs: SongModel[];

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
}