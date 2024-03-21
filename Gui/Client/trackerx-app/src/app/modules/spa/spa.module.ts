import { NgModule } from '@angular/core';
import { SpaRoutingModule } from './spa-routing.module';
import { NavigationModule } from './navigation/navigation.module';
import { RouterModule } from '@angular/router';
import { SpaContainerComponent } from './spa-container/spa-container.component';
import { DashboardModule } from './dashboard/dashboard.module';
import { AuthService } from 'src/app/providers/auth/auth.service';
import { MusicModule } from './assets/music/music.module';

@NgModule({
    declarations: [
        SpaContainerComponent
    ],
    imports: [
        RouterModule,
        SpaRoutingModule,
        NavigationModule,
        DashboardModule,
        MusicModule
    ],
    providers: [
        AuthService
    ],
    exports: [
        SpaContainerComponent
    ]
})
export class SpaModule { }
