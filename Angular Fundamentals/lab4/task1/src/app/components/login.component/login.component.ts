import { Component, inject } from "@angular/core";
import { Router, RouterLink } from "@angular/router";

@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  imports: [RouterLink]
})
export class LoginComponent {
  loginData = {
    email: '',
    password: '',
    remember: false
  }

  router: Router = inject(Router);

  login() {
    // console.log(this.loginData);

    let users: string | null;
    users = localStorage.getItem('users');

    if (!users) {
      this.router.navigate(['/signup']);
    } else {
      let usersArray = JSON.parse(users);
      let user = usersArray.find((user: any) => user.email === this.loginData.email && user.password === this.loginData.password);

      if (!user) {
        alert('Invalid email or password');
      } else {

        if (this.loginData.remember) {
          localStorage.setItem('user', JSON.stringify(user));
        } else {
          sessionStorage.setItem('user', JSON.stringify(user));
        }

        this.router.navigate(['/home']);
      }
    }
  }
}
