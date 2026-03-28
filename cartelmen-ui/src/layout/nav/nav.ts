import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../../core/services/account-service';
import { UserCredentials } from '../../app/model/user';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { ToastService } from '../../core/services/toast-service';

@Component({
  selector: 'app-nav',
  imports: [FormsModule, RouterLink, RouterLinkActive],
  templateUrl: './nav.html',
  styleUrl: './nav.css'
})
export class Nav {
  protected toastService = inject(ToastService)
  protected accountService = inject(AccountService);
  private router = inject(Router);
  protected credentials = {} as UserCredentials;

  login() {
    console.log(this.credentials)
    this.accountService.login(this.credentials).subscribe({
      next: response => {
        this.toastService.Success('Login successful!');
        this.router.navigateByUrl('/log-time'); // Navigate to the log-time page after successful login
        this.credentials = {} as UserCredentials; // Clear credentials after successful login
      },
      error: error => {console.error('Login failed:', error)
        this.toastService.Error(`Login failed: ${error.message || 'Unknown error'}`);
      }
    });
  }

  logout() {
    this.router.navigateByUrl('/');
    this.accountService.logout();
  }

  showToast() {   
     console.log('This is a toast message!');
      this.toastService.Info('This is a toast message!');
      this.toastService.Success('This is a toast message!');
      this.toastService.Warning('This is a toast message!');
      this.toastService.Error('This is a toast message!');
  }

}
