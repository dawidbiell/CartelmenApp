import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { HttpClientService } from './building/services/http-client.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(private http: HttpClient) {}

  buildingService = inject(HttpClientService)
  ngOnInit() {
    this.buildingService.getBuldings()
  }

  title = 'cartelmenapp.client';
}
