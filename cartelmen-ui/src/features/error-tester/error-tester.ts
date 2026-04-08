import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';

@Component({
  selector: 'app-error-tester',
  imports: [],
  templateUrl: './error-tester.html',
  styleUrl: './error-tester.css'
})
export class ErrorTester {
  private httpClient =inject(HttpClient);

  private baseURL = 'http://localhost:5000/api/';
  

  get401Unauthorized() {
    this.httpClient.get(this.baseURL + 'error/auth').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    });
  }

  get404NotFound() {
    this.httpClient.get(this.baseURL + 'error/not-found').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    });
  }
  get500ServerError() {
    this.httpClient.get(this.baseURL + 'error/server-error').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    });
  }
  get400BadRequest() {
    this.httpClient.get(this.baseURL + 'error/bad-request').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    });
  }
}
