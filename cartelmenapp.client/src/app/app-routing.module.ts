import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';

const routes: Routes = [
  { path: '', redirectTo: '/building/create', pathMatch: 'full' },
  // { path: '', component: AppComponent },
  { path: 'building', loadChildren: () => import('./building/building.module').then(m => m.BuildingModule) },
  // Dodaj inne ścieżki tutaj
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
