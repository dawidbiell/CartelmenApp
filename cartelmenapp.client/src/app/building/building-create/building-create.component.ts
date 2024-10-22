import { Component } from '@angular/core';
import { BuildingDto } from '../model/building.model';
import { BuildingService } from '../services/building.service';

@Component({
  selector: 'app-building-create',
  templateUrl: './building-create.component.html',
  styleUrls: ['./building-create.component.css']
})
export class BuildingCreateComponent {
  constructor(private buildingService: BuildingService ) {}
  building: BuildingDto = {
    name: '',
    description: '',
    startDate: undefined,
    country: '',
    city: '',
    street: '',
    postalCode: ''
  };


  onSubmit() {
    this.buildingService.createBuilding(this.building).subscribe({
      next: (response) => console.log('Building added', response),
      error: (error) => console.error('Error adding building:', error)
    });
  }
}
