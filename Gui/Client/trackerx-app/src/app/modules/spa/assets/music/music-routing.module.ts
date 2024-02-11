import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/providers/auth/auth.guard';

const routes: Routes = [
    {
        path: 'global',
        loadChildren: () => import('./song-global/song-global.module').then(m => m.SongGlobalModule),   
		canActivate: [ AuthGuard ]
    },
    {
        path: 'add',
        loadChildren: () => import('./music-create/music-create.module').then(m => m.MusicCreateModule),
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
