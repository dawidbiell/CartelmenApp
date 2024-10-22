import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BuildingComponent } from './building.component';
import { BuildingCreateComponent } from './building-create/building-create.component';

const routes: Routes = [
  { path: '', component: BuildingComponent },
  { path: 'create', component: BuildingCreateComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BuildingRoutingModule { }
