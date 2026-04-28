import { Location } from '@angular/common';
import { Component, inject, signal } from '@angular/core';
import { ApiError } from '../../../app/model/error';

@Component({
  selector: 'app-server-error',
  imports: [],
  templateUrl: './server-error.html',
  styleUrl: './server-error.css'
})
export class ServerError {
  protected error = signal<ApiError | null>(null);
  private location = inject(Location);
  protected showDetails = false;

  constructor() {
    const state = this.location.getState() as { error?: ApiError };
    this.error.set(state.error ?? null);
  }

  detailsToggle() {
    this.showDetails = !this.showDetails;
  }

  goBack() {
    this.location.back();
  }
}
