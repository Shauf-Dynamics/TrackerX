import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BandComponent } from './band/band.component';

const routes: Routes = [
  {
    path: 'setting/band',
    component: BandComponent,
    children: [
      {
        path: 'band',
        loadChildren: () =>
        import('./band/band.module').then((m) => m.BandModule)

      }
    ]
  },
  {
    path: 'setting',
    pathMatch: 'full',
    redirectTo: 'setting/band'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class SettingRoutingModule { }