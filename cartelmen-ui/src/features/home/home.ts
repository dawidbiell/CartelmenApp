import { Component } from '@angular/core';
import { Register } from '../account/register/register';

@Component({
  selector: 'app-home',
  imports: [Register],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home {
  protected registreMode = false;

  toggleRegistreMode() {
    this.registreMode = !this.registreMode;
  }
  SetRegisterMode() {
    this.registreMode = true;
  }
}
