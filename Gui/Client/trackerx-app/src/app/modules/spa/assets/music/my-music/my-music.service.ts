import { HttpClient, HttpParams } from "@angular/common/http";
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
            .set('includePublished', searchArgs.includePublished != null ? searchArgs.includePublished : "");    

        return this.http.get<MyMusicViewModel[]>(            
            environment.apiUrl + '/api/v1/music-profile/search', { params: params });
    }
}