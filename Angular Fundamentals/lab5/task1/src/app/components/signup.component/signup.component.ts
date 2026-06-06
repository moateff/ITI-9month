import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { passwordMatchValidator } from '../../validators/passwordMatch.validator';
import { UserType } from '../../types/user.type';
import { AccountService } from '../../services/account.service/account.service';

@Component({
  selector: 'app-signup',
  standalone: true,
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css',
  imports: [RouterLink, ReactiveFormsModule]
})
export class SignupComponent {

  private fb = inject(FormBuilder);

  private accountService = inject(AccountService);

  signupForm = this.fb.group(
    {
      name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', [Validators.required]]
    },
    { validators: passwordMatchValidator }
  );


  submit() {
    if (this.signupForm.invalid) {
      this.signupForm.markAllAsTouched();
      return;
    }

    const signupData: any = this.signupForm.value;

    this.accountService.register(signupData);
  }
}
