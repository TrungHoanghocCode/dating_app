import { Component, inject, OnInit, } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NgFor],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent implements OnInit{
  
  title = 'client';

  // // co the day inject bang cach nay , tuy nhien ko con dung nua 
  // constructor (private HttpClient : HttpClient) {}
  // // thay vao do thi dung ham inject cua Angular: 
  http = inject(HttpClient)

  users:any;

  ngOnInit(): void {
    // throw new Error('Method not implemented.');
    this.http.get("http://localhost:5000/api/Users").subscribe({
      next : (response) => {this.users = response},
      error: (err) => {console.log(err);},
      complete: () => {console.log("Request has completed !!!");},
    })
  } 
}
