import { inject, Injectable } from '@angular/core';
import { UserService } from '../user.service/user.service';
import { UserType } from '../../types/user.type';
import { v4 as uuidv4 } from 'uuid';
import { LoginType } from '../../types/login.type';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private userService: UserService = inject(UserService);

  private router: Router = inject(Router);

  register(user: UserType) {
    user.id = uuidv4();

    return this.userService.addUser(user).subscribe({
      next: () => {
        console.log('Account created successfully');

        this.router.navigate(['/login']);
      },
      error: (error) => {
        console.error(error);
      }
    });
  }

  login(data: LoginType) {
    let users: UserType[] | null;

    this.userService.getUsers().subscribe({
      next: (users) => {
        
        let user = users.find((user: UserType) => user.email === data.email && user.password === data.password);

        if (user) {

          console.log('Logged in successfully');

          if (data.remember) {
            localStorage.setItem('user', JSON.stringify(user));
          } else {
            sessionStorage.setItem('user', JSON.stringify(user));
          }

          this.router.navigate(['/home']);
        } else {

          console.log('Login failed');

          alert('Email or password is incorrect');
        }
      },
      error: (error) => {
        console.error(error);
      }
    })
  }

  logout() {
    localStorage.removeItem('user');
    sessionStorage.removeItem('user');

    console.log('Logged out successfully');
  }
}

