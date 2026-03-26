import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit, signal } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Nav } from "../layout/nav/nav";
import { MockSpotService } from './mocks/mock.spot';
import { AccountService } from '../core/services/account-service';
import { Router, RouterOutlet } from '@angular/router';


@Component({
  selector: 'app-root',
  imports: [Nav, RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  private accountService = inject(AccountService);
  protected router = inject(Router);
  protected readonly title = signal('Cartelmen App');
  protected spots = signal<any>([]);

  async ngOnInit(): Promise<void> {
    this.spots.set(await this.getSpots());
    this.setCurrentUser();
  }

  setCurrentUser(): void {
    const userJson = localStorage.getItem('user');
    if (!userJson) return;
    const user = JSON.parse(userJson);
    this.accountService.currentUser.set(user);
  }
  
  async getSpots() {
    try {
      return lastValueFrom(MockSpotService.prototype.getSpots()) // MockSpotService.prototype.getSpots() or (this.httpClient.get('http://localhost:5000/api/spots'));
        // this.httpClient.get('http://localhost:5000/api/spots'))
    } catch (error) {
      console.error('Error fetching spots:', error);
      throw error;
    }
  }
}
