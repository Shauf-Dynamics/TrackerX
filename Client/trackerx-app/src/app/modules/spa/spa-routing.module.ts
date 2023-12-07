import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes:Routes = [
    {
        path: 'app/music',
        loadChildren: () => import('./assets/music/music.module').then(m => m.MusicModule)
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
