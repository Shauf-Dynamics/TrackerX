import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/providers/auth/auth.guard';
import { MyMusicModule } from './my-music/my-music.module';

const routes: Routes = [
    {
        path: 'own',
        loadChildren: () => import('./my-music/my-music.module').then(m => MyMusicModule),
        canActivate: [AuthGuard]
    },
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
