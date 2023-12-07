import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/providers/auth/auth.guard';
import { MusicGlobalComponent } from './music-global/music-global.component';

const routes: Routes = [
    {
        path: 'global',
        component: MusicGlobalComponent,        
		canActivate: [ AuthGuard ]
    },
    {
        path: '', redirectTo: 'global', pathMatch: 'full'
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class MusicRoutingModule {

}
