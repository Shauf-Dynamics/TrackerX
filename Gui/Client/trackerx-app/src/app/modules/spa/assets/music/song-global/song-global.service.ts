import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { SearchModel, MusicModel, MusicDetailsModel as SongDetailsModel } from "./song-global.models";
import { environment } from "src/environments/environment";

@Injectable()
export class SongSearchService {    
    constructor(private http: HttpClient) { }

    public getMusicList(search: SearchModel): Observable<MusicModel[]> {
        let params = new HttpParams();    
        params = params.append('searchText', search.searchText);
        params = params.append('searchBy', search.searchBy);

        return this.http.get<MusicModel[]>(
            environment.apiUrl + '/api/v1/song/search', { params: params });
    }

    public getMusicDetails(songId: number): Observable<SongDetailsModel> {
        let params = new HttpParams();    
        params = params.append('songId', songId);

        return this.http.get<SongDetailsModel>(
            environment.apiUrl + '/api/v1/song/details', { params: params });
    }
}