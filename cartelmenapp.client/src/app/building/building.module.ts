import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BuildingRoutingModule } from './building-routing.module';
import { BuildingComponent } from './building.component';
import { SharedModule } from '../shared/shared.module';
import { FormsModule } from '@angular/forms';
import { BuildingCreateComponent } from './building-create/building-create.component';


@NgModule({
  declarations: [
    BuildingComponent,
    BuildingCreateComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    BuildingRoutingModule
  ]
})
export class BuildingModule { }
