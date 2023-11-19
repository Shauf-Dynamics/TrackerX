import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from './providers/auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {	
	public isLoggedIn$: Observable<boolean> = this.authService.isAuthorized$;

	constructor(private authService: AuthService) { }	
}
