import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/providers/auth/auth.service';
import { AuthSessionStorage } from 'src/app/providers/auth/auth.session';

@Component({
    selector: 'tx-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
    public currentVersion: string;
    public currentUserName: string;

    constructor(
        private authService: AuthService,
        private router: Router,
        private userStorage: AuthSessionStorage) { }

    ngOnInit(): void {        
        this.currentVersion = JSON.parse(localStorage.getItem('version')!);
        this.currentUserName = this.userStorage.getCurrentUser().userName;
    }

    public logOut() {
        this.authService.signOut()
        .subscribe(_ => {
            this.router.navigateByUrl('/login');
        });
    }
}
