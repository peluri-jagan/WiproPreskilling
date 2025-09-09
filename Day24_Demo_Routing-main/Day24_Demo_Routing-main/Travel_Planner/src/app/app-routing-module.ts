import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Home } from './home-component/home';

export const routes: Routes = [
  { path: '', component: Home },
  {
    path: 'destinations',
    loadComponent: () =>
      import('./destinations-component/destinations')
        .then(m => m.DestinationsComponent)
  },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
