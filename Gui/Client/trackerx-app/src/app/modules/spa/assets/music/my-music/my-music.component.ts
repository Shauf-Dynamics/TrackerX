import { Component, OnInit } from "@angular/core";
import { Observable, of } from "rxjs";
import { MyMusicViewModel } from "./my-music.models";
import { DatePipe } from "@angular/common";

@Component({
    selector: 'tx-my-music',
    templateUrl: './my-music.component.html',
    styleUrls: ['./my-music.component.css'],
    providers: [DatePipe]
})
export class MyMusicComponent implements OnInit {
    
    public myMusicViewModel$: Observable<MyMusicViewModel[]>;

    constructor(private datePipe: DatePipe) {
                
    }

    ngOnInit(): void {
        this.myMusicViewModel$ = of([
                new MyMusicViewModel(1, 'descr1', 't', 'v', new Date()),
                new MyMusicViewModel(2, 'descr2', 't', 'v', new Date()),
                new MyMusicViewModel(3, 'descr3', 't', 'v', new Date()),
                new MyMusicViewModel(4, 'descr4', 't', 'v', new Date()),
                new MyMusicViewModel(5, 'descr5', 't', 'v', new Date())
            ]
        )
    }
    
}