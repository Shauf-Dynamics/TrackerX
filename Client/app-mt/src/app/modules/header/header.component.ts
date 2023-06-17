import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-mt-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
    constructor(private route: ActivatedRoute, private router: Router) { }

  public onSettingClick(): void {
    this.router.navigate(['/setting']);
  }
}
