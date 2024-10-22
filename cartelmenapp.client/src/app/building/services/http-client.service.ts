import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BuildingDto } from '../model/building.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpClientService {

  private apiUrl = 'http://localhost:5000/api'; // URL do Twojego API

  constructor(private http: HttpClient) { }

  // Metoda do zapisywania BuildingDto
  createBuilding(building: BuildingDto): Observable<BuildingDto> {
    return this.http.post<BuildingDto>(this.apiUrl +'/building', building);
  }

  getBuldings(): Observable<BuildingDto[]> {
    return this.http.get<BuildingDto[]>(this.apiUrl + '/building');
  }
}
