import { Component,  inject,  input, output,  } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import {  ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  // @Input() usersFormHome : any;
  // @Output() cancelRegister = new EventEmitter();

  private accountService = inject(AccountService);
  private toast = inject(ToastrService);

  cancelRegister = output<boolean>();
  usersFormHome  = input.required<any>();


  model : any = {};


  register() {
    console.log(this.model);
    this.accountService.registerAccS(this.model).subscribe({
      next: response => {
        console.log(response);
        this.cancel();
      },
      error: err => {
        this.toast.error(err.error)
      }
    })
  };

  cancel() {
    console.log("ok, canceled !");
    this.cancelRegister.emit(false)
  }

}
