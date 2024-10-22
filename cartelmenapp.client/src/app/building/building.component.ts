import { Component } from '@angular/core';
import { BuildingDto } from './model/building.model';
import { HttpClientService } from './services/http-client.service';

@Component({
  selector: 'app-building',
  templateUrl: './building.component.html',
  styleUrls: ['./building.component.css']
})
export class BuildingComponent {
  building: BuildingDto = {
    name: '',
    description: '',
    startDate: new Date(),
    country: '',
    city: '',
    street: '',
    postalCode: ''
  };

  constructor(private httpClientService: HttpClientService) {}

  onSubmit() {
    this.httpClientService.createBuilding(this.building);
  }
}
