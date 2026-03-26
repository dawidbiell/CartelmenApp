import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../../core/services/account-service';
import { UserCredentials } from '../../app/model/user';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-nav',
  imports: [FormsModule, RouterLink, RouterLinkActive],
  templateUrl: './nav.html',
  styleUrl: './nav.css'
})
export class Nav {
  protected accountService = inject(AccountService);
  protected credentials: any = {};

  login() {
    console.log(this.credentials)
    this.accountService.login(this.credentials).subscribe({
      next: response => {
        console.log('Login successful:', response);
        this.credentials = {}; // Clear credentials after successful login
      },
      error: error => console.error('Login failed:', error)
    });
  }

  logout() {
    this.accountService.logout();
  }

}
