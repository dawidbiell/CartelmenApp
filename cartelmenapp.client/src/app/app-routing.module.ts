import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';

const routes: Routes = [
  { path: '', redirectTo: '/worker', pathMatch: 'full' },
  // { path: '', component: AppComponent },
  { path: 'building', loadChildren: () => import('./building/building.module').then(m => m.BuildingModule) },
  { path: 'worker', loadChildren: () => import('./worker/worker.module').then(m => m.WorkerModule) },
  // Dodaj inne ścieżki tutaj
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
