import { Component, inject, OnInit } from '@angular/core';
import { BuildingService } from './building/services/building.service';
import { BuildingDto } from './building/model/building.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'cartelmenapp.client';
  buildings: BuildingDto[] = [];

  buildingService = inject(BuildingService)

  ngOnInit() {
    this.buildingService.getBuldings().subscribe({
      next: response => this.buildings = response,
      error: error => console.error(error),
      complete: () => console.log("getBuldings() request compleated")
    })
  }

}
