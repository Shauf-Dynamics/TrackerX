import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AlbumSuggestionResult, BandSuggestionResult, GenreModel, SongCreateModel } from "./music-create.models";
import { environment } from "src/environments/environment";

const DefaultSuggestionPageSize: number = 5;

@Injectable()
export class MusicCreateService {    
    constructor(private http: HttpClient) { }
    
    public getMusicGenres(): Observable<GenreModel[]> {        
        return this.http.get<GenreModel[]>(            
            environment.apiUrl + '/api/music/create/v1/genres-list');
    }

    public getBandsSuggestion(pattern: string): Observable<BandSuggestionResult[]> {
        let params = new HttpParams()
            .set('pageSize', DefaultSuggestionPageSize)
            .set('startsWith', pattern);    

        return this.http.get<BandSuggestionResult[]>(
            environment.apiUrl + '/api/band/v1/search', { params: params });
    }

    public getAlbumsSuggestion(bandId: number): Observable<AlbumSuggestionResult[]> {
        let params = new HttpParams()            
            .set('bandId', bandId);    

        return this.http.get<AlbumSuggestionResult[]>(
            environment.apiUrl + '/api/album/v1/byBand', { params: params });
    }

    public createSong(model: SongCreateModel): Observable<any> {
        return this.http.post(
            environment.apiUrl + '/api/song/v1', model);
    }
}