import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Building } from '../model/building.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BuildingService {

  private apiUrl = 'http://localhost:5000/api'; // URL do Twojego API

  constructor(private http: HttpClient) { }

  create(building: Building): Observable<Building> {
    return this.http.post<Building>(this.apiUrl +'/building', building);
  }

  getBuldings(): Observable<Building[]> {
    return this.http.get<Building[]>(this.apiUrl + '/building');
  }
}
