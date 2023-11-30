import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes:Routes = [
    {
        path: 'app/songs',
        loadChildren: () => import('./assets/songs/songs.module').then(m => m.SongsModule)
    },
    {
        path: 'app/dashboard',
        loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule)
    },
    {
        path: '', redirectTo: 'app/dashboard', pathMatch: 'full'
    },
    {
        path: '**', redirectTo: 'app/dashboard', pathMatch: 'full'
    }
];
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class SpaRoutingModule { }
