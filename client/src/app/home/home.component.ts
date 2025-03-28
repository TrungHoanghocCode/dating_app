import { Component, inject, OnInit } from '@angular/core';
import { RegisterComponent } from "../register/register.component";
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RegisterComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{
  registerMode = false;
  users:any;
  http = inject(HttpClient) ;

  ngOnInit(): void {
    this.getUser()
  }

  registerToggle () {
    this.registerMode = !this.registerMode;
  }

  cancelRegisterMode(event : boolean) {
    this.registerMode = event
    // console.log(this.registerMode);
  }

  getUser() {
    this.http.get("http://localhost:5000/api/Users").subscribe({
      next : (response) => {this.users = response},
      error: (err) => {console.log(err);},
      complete: () => {console.log("Request has completed !!!");},
    })

}
}