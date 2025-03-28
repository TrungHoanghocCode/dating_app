import { Component, inject, OnInit, } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavComponent } from "./nav/nav.component";
import { AccountService } from './_services/account.service';
import { HomeComponent } from "./home/home.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,
    NavComponent, HomeComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent implements OnInit{
  private accountService = inject(AccountService);
  title = 'datingApp';

  // // co the day inject bang cach nay , tuy nhien ko con dung nua 
  // constructor (private HttpClient : HttpClient) {}
  // // thay vao do thi dung ham inject cua Angular: 
  // http = inject(HttpClient) ==> home
  // users:any; ==> home

  ngOnInit(): void {
    // this.getUser(); ==> home 
    this.setCurrentUser();
  } 

  setCurrentUser(){ 
    const userString = localStorage.getItem("user");
    if (!userString) return;

    const user = JSON.parse(userString);
    this.accountService.currentUser.set(user)
  }
}

