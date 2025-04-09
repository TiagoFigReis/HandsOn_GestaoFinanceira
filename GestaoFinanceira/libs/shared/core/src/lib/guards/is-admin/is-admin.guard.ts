import { CanActivate, Router, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { AuthenticationService } from '../../services/authentication/authentication.service';

@Injectable({
  providedIn: 'root',
})
export class IsAdminGuard implements CanActivate {
  constructor(
    private authenticationService: AuthenticationService,
    private router: Router
  ) {}

  canActivate():
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    const data = this.authenticationService.decodedToken;

    if (data.role !== 'Admin') {
      this.router.navigate(['/app']);
      return false;
    }

    return true;
  }
}
