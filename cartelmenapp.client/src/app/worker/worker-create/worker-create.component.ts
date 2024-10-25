import { Component } from '@angular/core';
import { Worker } from '../model/worker.model';
import { WorkerService } from '../services/worker.service';

@Component({
  selector: 'app-worker-create',
  templateUrl: './worker-create.component.html',
  styleUrls: ['./worker-create.component.css'],
})
export class WorkerCreateComponent {
  worker: Worker = {
    firstName: '',
    lastName: '',
    phone: '',
    email: '',
    payRate: 0,
    hiringDate: undefined,
  };

  constructor(private workerService: WorkerService) {}

  onSubmit() {
    this.workerService.create(this.worker).subscribe({
      next: (response) => {
        console.log('Worker successfully created:', response);
      },
      error: (error) => {
        console.error('Error creating worker:', error);
      },
    });
  }
}
