import { Component, OnInit } from '@angular/core';
import { Band } from './band.models';

@Component({
  selector: 'band-contaner',
  templateUrl: './band.component.html',
  styleUrls: ['./band.component.css']
})
export class BandComponent implements OnInit {

  public band$: Band[] = [];

  constructor() {

  }

  ngOnInit(): void {
    this.band$ = [
      new Band(0, "Metallica", 2),
      new Band(1, "Megadeth", 5),
      new Band(2, "Pantera", 0),
      new Band(3, "Marty Friedman", 1),
      new Band(4, "Anthrax", 2)
    ]
  }
}
