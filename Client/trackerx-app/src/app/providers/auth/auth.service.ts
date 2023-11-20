import { HttpClient, HttpHeaders, HttpResponse } from "@angular/common/http";
import { Injectable, OnInit } from "@angular/core";
import { BehaviorSubject, Observable, map, tap } from "rxjs";
import { UserClaims } from "./auth.models";
import { AuthSessionStorage } from "./auth.session";

@Injectable()
export class AuthService implements OnInit {
    public isAuthorized$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

    private baseApiUrl: string = 'https://localhost:7243';
    private baseAppUrl: string = 'http://localhost:4200';

    constructor(private http: HttpClient, private sessionAuthStorage: AuthSessionStorage) { }

    ngOnInit(): void {
        this.isAuthorized$ = new BehaviorSubject<boolean>(this.sessionAuthStorage.getCurrentUser() !== null);
    }

    public registrate(email: string, name: string, password: string, invitationCode: string) : Observable<any> {
        const body = {
            email: email,
            name: name,
            password: password,
            invitationCode: invitationCode
        }

        const httpOptions = {
            observe: 'response' as 'response',                        
        };

        return this.http.post<UserClaims>(this.baseApiUrl + '/api/account/registration/v1/via-link', body, httpOptions);
    }

    public signIn(login: string, password: string): Observable<HttpResponse<UserClaims>> {
        const body = {
            login: login,
            password: password
        }

        const httpOptions = {
            observe: 'response' as 'response',
            withCredentials: true,
            headers: this.getHttpsHeaders(),
        };

        return this.http.post<UserClaims>(this.baseApiUrl + '/api/account/v1/auth', body, httpOptions)
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

    private getHttpsHeaders(): HttpHeaders {
        return new HttpHeaders({
            'Access-Control-Allow-Origin': this.baseAppUrl,
            'Access-Control-Allow-Credentials': 'true',
            'Access-Control-Allow-Methods': 'GET,POST,OPTIONS,DELETE,PUT',
            'Access-Control-Allow-Headers': 'Headers: Content-Type'
        });
    }
}