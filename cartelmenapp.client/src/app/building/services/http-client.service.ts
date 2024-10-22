import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BuildingDto } from '../model/building.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpClientService {

  private apiUrl = 'http://localhost:4200/api'; // URL do Twojego API

  constructor(private http: HttpClient) { }

  // Metoda do zapisywania BuildingDto
  createBuilding(building: BuildingDto): Observable<BuildingDto> {
    return this.http.post<BuildingDto>(this.apiUrl +'/building', building);
  }

  getBuldings(): void {
    this.http.get('http://localhost:5000/api/buildings').subscribe({
      next: response => response,
      error: error => console.error(error),
      complete: () => console.log("Request compleated")
      

      
    })
  }
}
