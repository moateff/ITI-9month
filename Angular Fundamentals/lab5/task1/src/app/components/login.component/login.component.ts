import { Component, inject } from "@angular/core";
import { RouterLink } from "@angular/router";
import { FormsModule } from '@angular/forms';
import { AccountService } from "../../services/account.service/account.service";

@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  imports: [RouterLink, FormsModule]
})
export class LoginComponent {

  accountService: AccountService = inject(AccountService);

  submit(loginForm: any) {
    if (loginForm.invalid) {
      loginForm.markAllAsTouched();
      return;
    }

    const loginData: any = loginForm.value;

    this.accountService.login(loginData);
  }
}
