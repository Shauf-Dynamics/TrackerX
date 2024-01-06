import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/providers/auth/auth.service';

@Component({
    selector: 'tx-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.css']
})
export class HeaderComponent {
    constructor(
        private authService: AuthService,
        private router: Router) { }

    public logOut(event: any) {
        this.authService.signOut()
        .subscribe(_ => {
            this.router.navigateByUrl('/login');
        });
    }
}
