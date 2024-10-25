import { Component, inject, OnInit } from '@angular/core';
import { WorkerService } from './services/worker.service';
import { Worker } from './model/worker.model';

@Component({
  selector: 'app-worker',
  templateUrl: './worker.component.html',
  styleUrls: ['./worker.component.css']
})
export class WorkerComponent implements OnInit{
  
  workers: Worker[] = [];

  workerService = inject(WorkerService)

  ngOnInit() {
    this.workerService.getWorkers().subscribe({
      next: response => this.workers = response,
      error: error => console.error(error),
      complete: () => console.log("getBuldings() request compleated")
    })
  }
}
