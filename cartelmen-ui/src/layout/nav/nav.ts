import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../../core/services/account-service';

@Component({
  selector: 'app-nav',
  imports: [FormsModule],
  templateUrl: './nav.html',
  styleUrl: './nav.css'
})
export class Nav {
  private accountService = inject(AccountService);
  protected credentials: any = {}
  protected isLoggedIn = signal(false);

  login() {
    console.log(this.credentials)
    this.accountService.login(this.credentials).subscribe({
      next: response => {
        console.log('Login successful:', response);
        this.isLoggedIn.set(true);
        this.credentials = {}; // Clear credentials after successful login
      },
      error: error => console.error('Login failed:', error)
    });
  }

  logout() {

    this.isLoggedIn.set(false);
  }

}
