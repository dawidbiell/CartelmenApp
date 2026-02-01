import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit, signal } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Nav } from "../layout/nav/nav";


@Component({
  selector: 'app-root',
  imports: [Nav],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  private httpClient = inject(HttpClient);
  protected readonly title = signal('Cartelmen App');
  protected spots = signal<any>([]);

  async ngOnInit(): Promise<void> {
    this.spots.set(await this.getSpots());
  }

  async getSpots() {
    try {
      return lastValueFrom(this.httpClient.get('http://localhost:5000/api/spots'))
    } catch (error) {
      console.error('Error fetching spots:', error);
      throw error;
    }
  }
}
