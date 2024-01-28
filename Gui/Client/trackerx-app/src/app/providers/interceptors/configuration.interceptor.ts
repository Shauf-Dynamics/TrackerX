import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpResponse, HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";

@Injectable()
export class ConfigurationInterceptor implements HttpInterceptor {
    private configurationUrl: string = '/api/configuration';

    constructor(private http: HttpClient) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (!localStorage.getItem('version') && !request.url.includes(this.configurationUrl)) {
            this.callGetConfiguration().subscribe((x: any) => {
                localStorage.setItem('version', JSON.stringify(x.version));
            })
        }

        return next.handle(request);
    }

    private callGetConfiguration(): Observable<HttpResponse<any>> {        
        return this.http.get<any>(environment.apiUrl + this.configurationUrl);
    }
}