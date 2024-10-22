import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BuildingRoutingModule } from './building-routing.module';
import { BuildingComponent } from './building.component';
import { SharedModule } from '../shared/shared.module';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    BuildingComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    // FormsModule,
    BuildingRoutingModule
  ]
})
export class BuildingModule { }
