import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MusicCreateCommonComponent } from './music-create-common/music-create-common.component';

const routes: Routes = [
    {
        path: '',
        component: MusicCreateCommonComponent,   
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class MusicCreateRoutingModule {

}
