import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { baseUrl } from '../../shared/baseUrl';
import { UserType } from '../../types/user.type';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  http: HttpClient = inject(HttpClient);

  getUsers() {
    return this.http.get<UserType[]>(baseUrl + '/users');
  }

  getUser(id: number) {
    return this.http.get<UserType>(baseUrl + '/users/' + id);
  }

  addUser(user: UserType) {
    return this.http.post<UserType>(baseUrl + '/users', user);
  }

  updateUser(user: UserType) {
    return this.http.put<UserType>(baseUrl + '/users', user);
  }

  deleteUser(id: number) {
    return this.http.delete<UserType>(baseUrl + '/users/' + id);
  }
}
