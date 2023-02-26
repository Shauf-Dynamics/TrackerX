import { Component } from '@angular/core';

@Component({
  selector: 'app-record-adding',
  templateUrl: './record-adding.component.html',
  styleUrls: ['./record-adding.component.css']
})
export class RecordAddingComponent {
  $dateNow: Date;

  constructor() {
    this.$dateNow = new Date();
  }
}
