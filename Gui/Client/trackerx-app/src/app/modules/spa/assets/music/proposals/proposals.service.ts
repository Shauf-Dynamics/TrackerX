import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ProposalSearchModel, ProposalView } from "./proposals.models";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";

@Injectable()
export class ProposalsService {    
    constructor(private http: HttpClient) { }

    public getProposals(searchArgs: ProposalSearchModel): Observable<ProposalView[]> {       
        let params = new HttpParams()
            .set('songPattern', searchArgs.songPattern)
            .set('status', searchArgs.status);        

        return this.http.get<ProposalView[]>(            
            environment.apiUrl + '/api/v1/proposal/search', { params: params });
    }
}