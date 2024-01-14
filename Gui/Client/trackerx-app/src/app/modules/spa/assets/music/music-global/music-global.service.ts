import { HttpClient, HttpParams, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { SearchModel, MusicModel, MusicDetailsModel } from "./music-global.models";

@Injectable()
export class MusicSearchService {
    private baseApiUrl: string = 'https://localhost:7243';

    constructor(private http: HttpClient) { }

    public getMusicList(search: SearchModel): Observable<MusicModel[]> {
        let params = new HttpParams();    
        params = params.append('searchText', search.searchText);
        params = params.append('searchBy', search.searchBy);

        return this.http.get<MusicModel[]>(
            this.baseApiUrl + '/api/music/search/v1', { params: params });
    }

    public getMusicDetails(musicId: number): Observable<MusicDetailsModel> {
        let params = new HttpParams();    
        params = params.append('musicId', musicId);

        return this.http.get<MusicDetailsModel>(
            this.baseApiUrl + '/api/music/search/v1/details', { params: params });
    }
}