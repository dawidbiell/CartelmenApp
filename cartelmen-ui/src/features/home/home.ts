import { Component, signal } from '@angular/core';
import { Register } from '../account/register/register';

@Component({
  selector: 'app-home',
  imports: [Register],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home {
  protected registreMode = signal(false);

  SetRegisterMode(value:boolean) {
    console.log(value);
    
    this.registreMode.set(value);
  }
}
