import { NgModule } from '@angular/core';
import { DashboardComponent } from './dashboard.component';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { AuthGuard } from 'src/app/providers/auth/auth.guard';

@NgModule({
    declarations: [
        DashboardComponent
    ],
    imports: [
        DashboardRoutingModule
    ],
    providers: [
        AuthGuard
    ],
})
export class DashboardModule { }
