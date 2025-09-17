import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit, signal } from '@angular/core';
import { lastValueFrom } from 'rxjs';


@Component({
  selector: 'app-root',
  imports: [],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  private httpClient = inject(HttpClient);
  protected readonly title = signal('Cartelmen App');
  protected buildings = signal<any>([]);

  async ngOnInit() {
    this.buildings.set(await this.getBuildings());
  }

  async getBuildings() {
    try {
      return lastValueFrom(this.httpClient.get('http://localhost:5000/api/buildings'))
    } catch (error) {
      console.error('Error fetching buildings:', error);
      throw error;
    }
  }
}
