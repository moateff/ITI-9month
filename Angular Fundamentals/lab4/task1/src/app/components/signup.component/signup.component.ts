import { Component, inject } from "@angular/core";
import { Router, RouterLink } from "@angular/router";

@Component({
  selector: 'app-signup',
  standalone: true,
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css',
  imports: [RouterLink]
})
export class SignupComponent {
  signupData = {
    name: '',
    email: '',
    password: '',
    confirmPassword: ''
  }

  router: Router = inject(Router);

  signup() {
    // console.log(this.signupData);

    let users: string | null;
    users = localStorage.getItem('users');

    if (users) {
      let usersArray = JSON.parse(users);

      if (usersArray.find((user: any) => user.email === this.signupData.email)) {
        alert('Email already exists');
        return;
      }

      usersArray.push(this.signupData);
      localStorage.setItem('users', JSON.stringify(usersArray));
    } else {
      localStorage.setItem('users', JSON.stringify([this.signupData]));
    }

    this.router.navigate(['/login']);
  }
}
