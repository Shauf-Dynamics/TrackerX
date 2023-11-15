import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'tx-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

    constructor(private http: HttpClient) {
        this.http.get<any[]>('https://localhost:7243/api/bands/v1/list?pageSize=5')
            .subscribe(x => console.log(x));
    }

    ngOnInit(): void {

    }
}
