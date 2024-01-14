import { HttpClient, HttpParams, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, tap } from "rxjs";
import { GenreModel } from "./music-create.models";

@Injectable()
export class MusicCreateService {
    private baseApiUrl: string = 'https://localhost:7243';

    constructor(private http: HttpClient) { }
    
    public getMusicGenres(): Observable<GenreModel[]> {        
        return this.http.get<GenreModel[]>(
            this.baseApiUrl + '/api/music/create/v1/genres');
    }
}