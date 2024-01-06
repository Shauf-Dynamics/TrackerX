import { HttpClient, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable, map, tap } from "rxjs";
import { UserClaims } from "./auth.models";
import { AuthSessionStorage } from "./auth.session";

@Injectable()
export class AuthService {
    public isAuthorized$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(this.sessionAuthStorage.getCurrentUser() !== null);

    private baseApiUrl: string = 'https://localhost:7243';
    private baseAppUrl: string = 'http://localhost:4200';

    constructor(private http: HttpClient, private sessionAuthStorage: AuthSessionStorage) { }

    public registrate(email: string, name: string, password: string, invitationCode: string) : Observable<any> {
        const body = {
            email: email,
            name: name,
            password: password,
            invitationCode: invitationCode
        }

        return this.http.post<UserClaims>(this.baseApiUrl + '/api/account/registration/v1/via-link', body, { observe: 'response' as 'response' });
    }

    public signIn(login: string, password: string): Observable<HttpResponse<UserClaims>> {
        return this.http.post<UserClaims>(
            this.baseApiUrl + '/api/account/v1/auth', { login, password }, {  observe: 'response' as 'response' })
            .pipe(tap(data => {
                this.sessionAuthStorage.storeUser(data.body);
                this.isAuthorized$.next(true);
            }));
    }

    public signOut(): Observable<any> {
        return this.http.get(this.baseApiUrl + '/api/account/v1/signout')
            .pipe(tap(_ => {
                 this.clearSession()                
            }));
    }

    public clearSession(): void {
        this.sessionAuthStorage.removeUser();
        this.isAuthorized$.next(false);
    }

    public isLoggedIn(): Observable<boolean> {
        return this.isAuthorized$
            .pipe(map(isAuthorized => isAuthorized && this.sessionAuthStorage.getCurrentUser() != null));      
    }

   /* private getHttpsHeaders(): HttpHeaders {
        return new HttpHeaders({
            'Access-Control-Allow-Origin': this.baseAppUrl,
            'Access-Control-Allow-Credentials': 'true',
            'Access-Control-Allow-Methods': 'GET,POST,OPTIONS,DELETE,PUT',
            'Access-Control-Allow-Headers': 'Headers: Content-Type'
        });
    }*/
}