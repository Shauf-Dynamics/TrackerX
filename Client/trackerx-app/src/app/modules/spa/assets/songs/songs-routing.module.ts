import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/providers/auth/auth.guard';
import { SongsContainerComponent } from './songs-container/songs-container.component';
import { SongsGlobalComponent } from './songs-search/songs-global/songs-global.component';

const routes: Routes = [
    {
        path: 'global',
        component: SongsGlobalComponent,        
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
export class SongsRoutingModule {

}
