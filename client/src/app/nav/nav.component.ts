import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import {  ToastrService } from 'ngx-toastr';
import { TitleCasePipe } from '@angular/common';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule, BsDropdownModule, RouterLink, RouterLinkActive, TitleCasePipe],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {

  private route = inject(Router)
  accountService = inject(AccountService);
  private toast = inject(ToastrService)
  // loggedIn = false;
  model : any = {};

  loginNav(){
    // console.log(this.model);
    this.accountService.loginAccS(this.model).subscribe({
      // next: response =>  {
      //   console.log(response);
      //   this.loggedIn =  true;
      // },

      next: _ => {
        this.route.navigateByUrl("/members")
      },
      error: err => {
        // console.log(err);
        this.toast.error(err.error)
      }
    })
  }

  logoutNav() {
    // this.loggedIn =  false;
    console.log("bye");
    this.accountService.logoutAccS();
    this.route.navigateByUrl("/")
  }
}
