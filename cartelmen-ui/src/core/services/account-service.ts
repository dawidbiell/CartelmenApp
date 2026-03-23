import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal, Signal } from '@angular/core';
import { User, UserCredentials } from '../../app/model/user';
import { of, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private http = inject(HttpClient);
  currentUser = signal<User | null>(null);

  baseURL = 'http://localhost:5000/api/account';

  login(credentials: UserCredentials) {
    // return this.http.post<User>(`${this.baseURL}/login`, credentials)

    return of({
      id: 1111111,
      username: "Dawid",
      email: "dawidbiell@gmail.com",
      token: "stringTOkenABC123"
    }).pipe(
      tap((user) => {
        this.currentUser.set(user);
        localStorage.setItem('user', JSON.stringify(user));
      })
    );
  }

  logout() {
    this.currentUser.set(null);
    localStorage.removeItem('user');
  };

}
