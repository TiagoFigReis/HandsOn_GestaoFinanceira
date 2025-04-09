import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CardComponent, UserFormComponent } from '@farm/ui';
import { User, UserFacade, AuthFacade } from '@farm/core';
import { Router } from '@angular/router';

@Component({
  selector: 'lib-sign-up',
  imports: [CommonModule, RouterModule, CardComponent, UserFormComponent],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.css',
})
export class SignUpComponent implements OnInit {
  loading = false;

  constructor(
    private userFacade: UserFacade,
    private authFacade: AuthFacade,
    private router: Router,
  ) {}

  ngOnInit(): void {
    if (this.authFacade.isAuthenticated) this.router.navigate(['/app']);
  }

  onSubmit(user: User) {
    this.loading = true;

    this.userFacade.registerMe(user).subscribe(
      () => {
        this.loading = false;
      },
      () => {
        this.loading = false;
      },
    );
  }
}
