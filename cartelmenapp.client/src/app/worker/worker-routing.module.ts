import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WorkerComponent } from './worker.component';
import { WorkerCreateComponent } from './worker-create/worker-create.component';

const routes: Routes = [
  { path: '', component: WorkerComponent },
  { path: 'create', component: WorkerCreateComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class WorkerRoutingModule {}
