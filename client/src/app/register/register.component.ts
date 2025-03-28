import { Component,  inject,  input, output,  } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';

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

  private accountService = inject(AccountService)

  cancelRegister = output<boolean>()
  usersFormHome  = input.required<any>();


  model : any = {};


  register() {
    console.log(this.model);
    this.accountService.registerAccS(this.model).subscribe({
      next: response => {
        console.log(response);
        this.cancel();
      },
      error: err => console.log(err)
    })
  };

  cancel() {
    console.log("ok, canceled !");
    this.cancelRegister.emit(false)
  }

}
