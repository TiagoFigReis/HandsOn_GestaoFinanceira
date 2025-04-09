import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ButtonComponent, InputComponent } from '@farm/ui';
import { AuthFacade } from '@farm/core';

@Component({
  selector: 'lib-forgot-password',
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    InputComponent,
    ButtonComponent,
  ],
  templateUrl: './forgot-password.component.html',
  styleUrl: './forgot-password.component.css',
})
export class ForgotPasswordComponent {
  signInForm: FormGroup;
  loading = false;

  constructor(private authFacade: AuthFacade) {
    this.signInForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
    });
  }

  get email(): FormControl {
    return this.signInForm.get('email') as FormControl;
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

    this.authFacade.sendPasswordResetEmail(this.email.value).subscribe({
      next: () => {
        this.loading = false;
      },
      error: () => {
        this.loading = false;
      },
    });
  }
}
