import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonComponent } from '@farm/ui';
import { AuthFacade, User, UserFacade } from '@farm/core';

@Component({
  selector: 'lib-change-password',
  imports: [CommonModule, ButtonComponent],
  templateUrl: './change-password.component.html',
  styleUrl: './change-password.component.css',
})
export class ChangePasswordComponent implements OnInit {
  user: User | undefined;
  loading = false;

  constructor(private authFacade: AuthFacade, private userFacade: UserFacade) {}

  ngOnInit(): void {
    this.userFacade.user$.subscribe((user) => {
      if (!user) return;

      this.user = user;
    });
  }

  onResetPassword() {
    if (!this.user) return;

    this.loading = true;

    this.authFacade.sendPasswordResetEmail(this.user.email).subscribe(() => {
      this.loading = false;
    });
  }
}
