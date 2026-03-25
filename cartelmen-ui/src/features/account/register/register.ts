import { Component, inject, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserRegisterCredentials } from '../../../app/model/user';
import { AccountService } from '../../../core/services/account-service';

@Component({
  selector: 'app-register',
  imports: [FormsModule],
  templateUrl: './register.html',
  styleUrl: './register.css'
})
export class Register {
  accountService = inject(AccountService);
  cancelRegister = output<boolean>();
  protected creds = {} as UserRegisterCredentials;

  protected register(): void {
    this.accountService.register(this.creds).subscribe({
      next: response => {
        console.log('Registration successful', response);
        this.cancel();
      },
      error: error => {
        console.error('Registration failed', error);
      }
    });
  }

  protected cancel(): void {
    this.cancelRegister.emit(true);
  }

}
