import { NgModule } from '@angular/core';
import { SpaRoutingModule } from './spa-routing.module';
import { NavigationModule } from './navigation/navigation.module';
import { RouterModule } from '@angular/router';
import { SpaContainerComponent } from './spa-container/spa-container.component';
import { DashboardModule } from './dashboard/dashboard.module';

@NgModule({
  declarations: [    
    SpaContainerComponent
  ],
  imports: [
    RouterModule,
    SpaRoutingModule,
    NavigationModule,
    DashboardModule
  ],
  providers: [

  ],
  exports: [
    SpaContainerComponent
  ]
})
export class SpaModule { }
