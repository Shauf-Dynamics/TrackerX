import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { SearchModel, MusicModel, MusicDetailsModel } from "./music-global.models";
import { environment } from "src/environments/environment";

@Injectable()
export class MusicSearchService {    
    constructor(private http: HttpClient) { }

    public getMusicList(search: SearchModel): Observable<MusicModel[]> {
        let params = new HttpParams();    
        params = params.append('searchText', search.searchText);
        params = params.append('searchBy', search.searchBy);

        return this.http.get<MusicModel[]>(
            environment.apiUrl + '/api/music/search/v1', { params: params });
    }

    public getMusicDetails(musicId: number): Observable<MusicDetailsModel> {
        let params = new HttpParams();    
        params = params.append('musicId', musicId);

        return this.http.get<MusicDetailsModel>(
            environment.apiUrl + '/api/music/search/v1/details', { params: params });
    }
}