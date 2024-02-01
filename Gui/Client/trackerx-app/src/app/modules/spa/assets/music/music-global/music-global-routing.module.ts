import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MusicGlobalComponent } from './music-global.component';

const routes: Routes = [
    {
        path: '',
        component: MusicGlobalComponent,   
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class MusicGlobalRoutingModule {

}
