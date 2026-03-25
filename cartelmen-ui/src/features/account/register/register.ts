import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserRegisterCredentials } from '../../../app/model/user';

@Component({
  selector: 'app-register',
  imports: [FormsModule],
  templateUrl: './register.html',
  styleUrl: './register.css'
})
export class Register {
  protected creds = {} as UserRegisterCredentials;

  protected register(): void {
    console.log(this.creds); 
  }

  protected cancel(): void {
    console.log('Registration cancelled');
  }

}
