import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'setting-container',
  templateUrl: './setting-container.component.html',
  styleUrls: ['./setting-container.component.css']
})
export class SettingContainerComponent {
  constructor(
    private route: ActivatedRoute,
    private router: Router  ) {}
}
