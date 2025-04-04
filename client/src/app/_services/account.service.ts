import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { User } from '../_models/users';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  // constructor() { }

  private http = inject(HttpClient)
  baseUrl = "http://localhost:5000/api/";
  currentUser = signal<User | null > (null)

  loginAccS(model : any) {
    // console.log("test");
    return this.http.post<User>(this.baseUrl + "account/login" , model).pipe (
      map (user => {
        if (user) {
          // console.log(user);
          localStorage.setItem("user",JSON.stringify(user));
          this.currentUser.set(user)
          return user;
        } else return null;
      })
    )
  }

  registerAccS(model : any) {
    return this.http.post<User>(this.baseUrl + "account/register" , model).pipe (
      map (user => {
        if (user) {
          localStorage.setItem("user",JSON.stringify(user));
          this.currentUser.set(user)
          return user;
        } else return null;
      })
    )
  }

  logoutAccS() {
    localStorage.removeItem("user");
    this.currentUser.set(null)
  }
}
