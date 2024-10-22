import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { HttpClientService } from './building/services/http-client.service';
import { BuildingDto } from './building/model/building.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  buildings: BuildingDto[] =[];

  buildingService = inject(HttpClientService)
  ngOnInit() {
    this.buildingService.getBuldings().subscribe({
      next: response => this.buildings = response,
      error: error => console.error(error),
      complete: () => console.log("getBuldings() request compleated")
    })
  }

  title = 'cartelmenapp.client';
}
