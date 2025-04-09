import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import {
  AuthFacade,
  NotificationService,
  validatePasswordMatch,
} from '@farm/core';
import {
  ButtonComponent,
  CardComponent,
  InputPasswordComponent,
} from '@farm/ui';
import { Router } from '@angular/router';

@Component({
  selector: 'lib-change-password',
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ButtonComponent,
    InputPasswordComponent,
    CardComponent,
  ],
  templateUrl: './change-password.component.html',
  styleUrl: './change-password.component.css',
})
export class ChangePasswordComponent implements OnInit {
  key: string | null = null;
  token: string | null = null;

  changePassword: FormGroup;
  loading = false;

  constructor(
    private authFacade: AuthFacade,
    private notificationService: NotificationService,
    private router: Router,
  ) {
    this.changePassword = new FormGroup({
      password: new FormControl('', {
        validators: [
          Validators.required,
          Validators.minLength(8),
          Validators.maxLength(18),
          Validators.pattern(
            /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,18}$/,
          ),
          validatePasswordMatch('confirmPassword'),
        ],
        updateOn: 'blur',
      }),
      confirmPassword: new FormControl('', {
        validators: [Validators.required, validatePasswordMatch('password')],
        updateOn: 'blur',
      }),
    });
  }

  ngOnInit() {
    this.key = this.getQueryParams('key');
    this.token = this.getQueryParams('token');

    if (!this.key || !this.token) {
      this.notificationService.error('Erro', 'Chave ou token inválidos');
      this.router.navigate(['/sign-in']);
      return;
    }

    this.loading = true;

    const tokenEncoded = encodeURIComponent(this.token);
    const keyEncoded = encodeURIComponent(this.key);

    this.authFacade.checkPasswordResetToken(keyEncoded, tokenEncoded).subscribe(
      () => {
        this.loading = false;
      },
      () => {
        this.loading = false;
      },
    );
  }

  get password(): FormControl {
    return this.changePassword.get('password') as FormControl;
  }

  get confirmPassword(): FormControl {
    return this.changePassword.get('confirmPassword') as FormControl;
  }

  getQueryParams(param: string) {
    const urlParams = new URLSearchParams(window.location.search);
    return urlParams.get(param);
  }

  onSubmit() {
    if (!this.key || !this.token) {
      this.notificationService.error('Erro', 'Chave ou token inválidos');
      return;
    }

    if (this.changePassword.invalid) {
      for (const key in this.changePassword.controls) {
        this.changePassword.controls[key].markAsDirty();
        this.changePassword.controls[key].updateValueAndValidity();
      }

      return;
    }

    const password = this.password.value;
    const confirmPassword = this.confirmPassword.value;

    this.authFacade
      .changePassword(this.key, this.token, password, confirmPassword)
      .subscribe(() => {
        this.loading = false;
      });
  }
}
