import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

import {
  FormGroupComponent,
  InputComponent,
  InputPasswordComponent,
  ButtonComponent,
  CheckboxComponent,
} from '@farm/ui';
import { AuthFacade, APP_CONFIG } from '@farm/core';

@Component({
  selector: 'lib-form',
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    FormGroupComponent,
    InputComponent,
    InputPasswordComponent,
    ButtonComponent,
    CheckboxComponent,
  ],
  templateUrl: './form.component.html',
  styleUrl: './form.component.css',
})
export class FormComponent implements OnInit {
  private readonly appConfig = inject(APP_CONFIG);

  signInForm: FormGroup;
  loading = false;
  loadingGoogle = false;

  constructor(private authFacade: AuthFacade) {
    this.signInForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
      rememberMe: new FormControl(false),
    });
  }

  ngOnInit() {
    this.checkIfEmailSaved();
  }

  get email(): FormControl {
    return this.signInForm.get('email') as FormControl;
  }

  get password(): FormControl {
    return this.signInForm.get('password') as FormControl;
  }

  get rememberMe(): FormControl {
    return this.signInForm.get('rememberMe') as FormControl;
  }

  checkIfEmailSaved() {
    const email = localStorage.getItem('email') || '';

    this.email.setValue(email);

    if (email) this.rememberMe.setValue(true);
  }

  onGoogleSignIn() {
    this.loadingGoogle = true;

    const clientId = this.appConfig.clientId;
    const redirectUri = encodeURIComponent(this.appConfig.redirectUri);

    const authUrl = `https://accounts.google.com/o/oauth2/v2/auth?client_id=${clientId}&redirect_uri=${redirectUri}&scope=openid%20profile%20email&response_type=code&access_type=offline&prompt=consent`;

    window.location.href = authUrl;
  }

  onSubmit() {
    this.signInForm.updateValueAndValidity();

    if (this.signInForm.invalid) {
      for (const key in this.signInForm.controls) {
        this.signInForm.controls[key].markAsDirty();
        this.signInForm.controls[key].updateValueAndValidity();
      }

      return;
    }

    this.loading = true;

    const { email, password, rememberMe } = this.signInForm.value;

    this.authFacade.login(email, password, rememberMe).subscribe(
      () => {
        this.loading = false;
      },
      () => {
        this.loading = false;
      },
    );
  }
}
