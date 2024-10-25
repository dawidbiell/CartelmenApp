import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Worker } from '../model/worker.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WorkerService {
  private apiUrl = 'http://localhost:5000/api'; // URL do Twojego API

  constructor(private http: HttpClient) { }

  create(worker: Worker): Observable<Worker> {
    return this.http.post<Worker>(this.apiUrl +'/worker', worker);
  }

  getWorkers(): Observable<Worker[]> {
    return this.http.get<Worker[]>(this.apiUrl + '/worker');
  }
}
