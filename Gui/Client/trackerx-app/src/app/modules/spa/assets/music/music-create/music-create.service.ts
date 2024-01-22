import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { GenreModel } from "./music-create.models";
import { environment } from "src/environments/environment";

@Injectable()
export class MusicCreateService {
    constructor(private http: HttpClient) { }
    
    public getMusicGenres(): Observable<GenreModel[]> {        
        return this.http.get<GenreModel[]>(            
            environment.apiUrl + '/api/music/create/v1/genres-list');
    }
}