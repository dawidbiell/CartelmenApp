import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WorkerRoutingModule } from './worker-routing.module';
import { WorkerComponent } from './worker.component';
import { WorkerCreateComponent } from './worker-create/worker-create.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    WorkerComponent,
    WorkerCreateComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    WorkerRoutingModule
  ]
})
export class WorkerModule { }
