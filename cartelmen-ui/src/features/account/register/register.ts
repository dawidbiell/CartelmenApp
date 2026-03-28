import { Component, inject, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserRegisterCredentials } from '../../../app/model/user';
import { AccountService } from '../../../core/services/account-service';
import { ToastService } from '../../../core/services/toast-service';

@Component({
  selector: 'app-register',
  imports: [FormsModule],
  templateUrl: './register.html',
  styleUrl: './register.css'
})
export class Register {
  accountService = inject(AccountService);
  toastService = inject(ToastService);
  cancelRegister = output<boolean>();
  protected creds = {} as UserRegisterCredentials;

  protected register(): void {
    this.accountService.register(this.creds).subscribe({
      next: response => {
        console.log('Registration successful', response);
        this.toastService.Success('Registration successful!');

        this.cancel();
      },
      error: error => {
        this.toastService.Error(`Registration failed: ${error.error?.message || 'Unknown error'}  `);
      }
    });
  }

  protected cancel(): void {
    this.cancelRegister.emit(true);
  }

}
