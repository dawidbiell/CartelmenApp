import { Component, inject, OnInit } from '@angular/core';
import { BuildingDto } from './model/building.model';
import { BuildingService } from './services/building.service';

@Component({
  selector: 'app-building',
  templateUrl: './building.component.html',
  styleUrls: ['./building.component.css']
})
export class BuildingComponent implements OnInit{
  
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
