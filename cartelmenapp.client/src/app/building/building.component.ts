import { Component } from '@angular/core';
import { BuildingDto } from './model/building.model';
import { BuildingService } from './services/building.service';

@Component({
  selector: 'app-building',
  templateUrl: './building.component.html',
  styleUrls: ['./building.component.css']
})
export class BuildingComponent {
  constructor(private buildingService: BuildingService) {}
  
  building: BuildingDto = {
    name: '',
    description: '',
    startDate: new Date(),
    country: '',
    city: '',
    street: '',
    postalCode: ''
  };


  onSubmit() {
    this.buildingService.createBuilding(this.building);
  }
}
