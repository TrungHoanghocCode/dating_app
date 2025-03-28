import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule, BsDropdownModule],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  accountService = inject(AccountService);
  // loggedIn = false;
  model : any = {};

  loginNav(){
    // console.log(this.model);
    this.accountService.loginAccS(this.model).subscribe({
      next: response =>  {
        console.log(response);
        // this.loggedIn =  true;
      },
      error: err => {
        console.log(err);
      }
    })
  }

  logoutNav() {
    // this.loggedIn =  false;
    console.log("bye");
    this.accountService.logoutAccS();
  }
}
