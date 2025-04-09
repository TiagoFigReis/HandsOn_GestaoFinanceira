import { Injectable } from '@angular/core';
import { catchError } from 'rxjs';
import { RequestService } from '../request/request.service';
import { User } from '../../models/user.model';
import { HttpContext } from '@angular/common/http';
import { BYPASS_INTERCEPTORS } from '../../interceptors/authentication/authentication.interceptor';

@Injectable({
  providedIn: 'root',
})
export class UserService extends RequestService {
  httpOptionsBypassInterceptor = {
    ...this.httpOptions,
    context: new HttpContext().set(BYPASS_INTERCEPTORS, true),
  };

  me() {
    return this.httpClient
      .get<User>(`${this.usersApiUrl}/me`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  getAllUsers() {
    return this.httpClient
      .get<User[]>(`${this.usersApiUrl}`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  getUserById(id: string) {
    return this.httpClient
      .get<User>(`${this.usersApiUrl}/${id}`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  checkEmail(email: string) {
    return this.httpClient
      .get<{ emailExists: boolean }>(
        `${this.usersApiUrl}/check-email?email=${email}`,
        this.httpOptionsBypassInterceptor,
      )
      .pipe(catchError(this.handleError));
  }

  checkPhone(phone: string) {
    return this.httpClient
      .get<{ phoneExists: boolean }>(
        `${this.usersApiUrl}/check-phone?phone=${phone}`,
        this.httpOptionsBypassInterceptor,
      )
      .pipe(catchError(this.handleError));
  }

  registerMe(user: User) {
    return this.httpClient
      .post<{
        token: string;
      }>(
        `${this.usersApiUrl}/register`,
        JSON.stringify(user),
        this.httpOptionsBypassInterceptor,
      )
      .pipe(catchError(this.handleError));
  }

  createUser(user: User) {
    return this.httpClient
      .post<User>(`${this.usersApiUrl}`, JSON.stringify(user), this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  updateUser(user: User) {
    return this.httpClient
      .put<User>(
        `${this.usersApiUrl}/${user.id}`,
        JSON.stringify(user),
        this.httpOptions,
      )
      .pipe(catchError(this.handleError));
  }

  updateMe(user: User) {
    return this.httpClient
      .put<User>(`${this.usersApiUrl}`, JSON.stringify(user), this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  deleteUser(id: string) {
    return this.httpClient
      .delete<void>(`${this.usersApiUrl}/${id}`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }
}
