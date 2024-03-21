import { HttpClient, HttpParams, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { MyMusicSearchArguments, MyMusicViewModel } from "./my-music.models";

@Injectable()
export class MyMusicService {    
    constructor(private http: HttpClient) { }
    
    public getMyMusic(searchArgs: MyMusicSearchArguments): Observable<MyMusicViewModel[]> {       
        let params = new HttpParams()
            .set('DescriptionPattern', searchArgs.descriptionPattern)
            .set('Type', searchArgs.type)
            .set('Publicity', searchArgs.publicity);    

        return this.http.get<MyMusicViewModel[]>(            
            environment.apiUrl + '/api/v1/music-profile/search', { params: params });
    }

    public openProposal(assetTypeId: number): Observable<any> {
        return this.http.post(
            environment.apiUrl + '/api/v1/proposal/open',
            {
                assetId: assetTypeId,
                assetType: "Song"
            }
        )
    }

    public removeSong(songId: number): Observable<any> {
        let params = new HttpParams()
            .set('songId', songId)

        return this.http.delete(
            environment.apiUrl + '/api/v1/song', { params: params });
    }

    public removeCustomMusic(customMusicId: number): Observable<any> {
        let params = new HttpParams()
            .set('customMusicId', customMusicId)

        return this.http.delete(
            environment.apiUrl + '/api/v1/custom-music', { params: params });
    }
}