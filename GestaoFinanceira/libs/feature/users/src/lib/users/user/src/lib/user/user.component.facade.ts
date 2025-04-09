import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import {
  User,
  UserFacade,
  ConfirmationService,
  AuthenticationService,
} from '@farm/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class UserComponentFacade {
  private userSubject = new BehaviorSubject<User | null>(null);
  private loadingSubject = new BehaviorSubject<boolean>(false);
  private selectRoleSubject = new BehaviorSubject<boolean>(false);

  id: string | undefined;
  isOwnProfile = false;
  user$: Observable<User | null> = this.userSubject.asObservable();
  loading$: Observable<boolean> = this.loadingSubject.asObservable();
  selectRole: Observable<boolean> = this.selectRoleSubject.asObservable();

  constructor(
    private authenticationService: AuthenticationService,
    private userFacade: UserFacade,
    private confirmationService: ConfirmationService,
    private router: Router,
  ) {}

  load(id: string) {
    const data = this.authenticationService.decodedToken;

    this.id = id;
    this.isOwnProfile = data.nameid === id;

    this.selectRoleSubject.next(!this.isOwnProfile);
    this.loadingSubject.next(true);

    this.userFacade
      .getUserById(id)
      .pipe(
        tap(
          (user) => {
            this.userSubject.next(user);
            this.loadingSubject.next(false);
          },
          (error) => {
            const code = error.code;
            if (code === 400 || code === 404) this.router.navigate(['/404']);
          },
        ),
      )
      .subscribe();
  }

  reset() {
    this.userSubject.next(null);
  }

  submit(user: User) {
    this.confirmationService.confirm({
      message: `Deseja ${this.id ? 'atualizar' : 'criar'} o usuário?`,
      accept: () => (this.id ? this.updateUser(user) : this.addUser(user)),
    });
  }

  addUser(user: User) {
    this.userFacade.createUser(user).subscribe(() => {
      this.router.navigate(['/app/users']);
    });
  }

  updateUser(user: User) {
    this.userFacade.updateUser(user).subscribe(() => {
      const data = this.authenticationService.decodedToken;
      if (data.nameid === user.id) this.authenticationService.logout();

      this.router.navigate(['/app/users']);
    });
  }
}
