import { CanActivate, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { AuthenticationService } from '../../services/authentication/authentication.service';

@Injectable({
  providedIn: 'root',
})
export class AuthenticatedGuard implements CanActivate {
  constructor(private authenticationService: AuthenticationService) {}

  canActivate():
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    const token = this.authenticationService.token;

    if (!token || this.authenticationService.tokenExpired) {
      this.authenticationService.logout();
      return false;
    }

    return true;
  }
}
