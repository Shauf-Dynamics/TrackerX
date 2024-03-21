import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SongGlobalComponent } from './song-global.component';

const routes: Routes = [
    {
        path: '',
        component: SongGlobalComponent,   
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class SongGlobalRoutingModule {

}
