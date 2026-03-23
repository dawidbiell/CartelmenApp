import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  imports: [],
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
