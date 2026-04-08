import { HttpClient } from '@angular/common/http';
import { Component, inject, signal, } from '@angular/core';
import { UserRegisterCredentials } from '../../app/model/user';

@Component({
  selector: 'app-error-tester',
  imports: [],
  templateUrl: './error-tester.html',
  styleUrl: './error-tester.css'
})
export class ErrorTester {
  private httpClient =inject(HttpClient);

  private baseURL = 'http://localhost:5000/api/';

  validationErrors = signal<string[]>([]);
  

  get401Unauthorized() {
    this.httpClient.get(this.baseURL + 'error/auth').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    });
  }
  get400ValidationError() {
    this.httpClient.post(this.baseURL + 'account/register', {} as UserRegisterCredentials).subscribe({
      next: response => console.log(response),
      error: error => {
        console.log(error);
        this.validationErrors.set(error);
      }
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
