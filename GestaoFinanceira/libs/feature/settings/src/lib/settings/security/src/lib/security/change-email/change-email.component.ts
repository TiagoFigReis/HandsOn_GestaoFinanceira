import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ButtonComponent, FormGroupComponent, InputComponent } from '@farm/ui';
import {
  AuthFacade,
  User,
  UserFacade,
  validateEmailExists,
  validateEmailsMatch,
} from '@farm/core';

@Component({
  selector: 'lib-change-email',
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ButtonComponent,
    InputComponent,
    FormGroupComponent,
  ],
  templateUrl: './change-email.component.html',
  styleUrl: './change-email.component.css',
})
export class ChangeEmailComponent {
  user: User | undefined;
  emailChangeForm: FormGroup;
  loading = false;

  constructor(private authFacade: AuthFacade, private userFacade: UserFacade) {
    this.emailChangeForm = new FormGroup({
      email: new FormControl('', {
        validators: [
          Validators.required,
          Validators.email,
          validateEmailsMatch('emailConfirmation'),
        ],
        updateOn: 'blur',
      }),
      emailConfirmation: new FormControl('', {
        validators: [
          Validators.required,
          Validators.email,
          validateEmailsMatch('email'),
        ],
        updateOn: 'blur',
      }),
    });

    this.userFacade.user$.subscribe((user) => {
      if (!user) return;

      this.user = user;

      this.email.addAsyncValidators(
        validateEmailExists(
          user.email,
          this.userFacade.checkEmail.bind(this.userFacade)
        )
      );
    });
  }

  get email(): FormControl {
    return this.emailChangeForm.get('email') as FormControl;
  }

  get emailConfirmation(): FormControl {
    return this.emailChangeForm.get('emailConfirmation') as FormControl;
  }

  onSubmit() {
    this.emailChangeForm.updateValueAndValidity();

    if (this.emailChangeForm.invalid) {
      for (const key in this.emailChangeForm.controls) {
        this.emailChangeForm.controls[key].markAsDirty();
        this.emailChangeForm.controls[key].updateValueAndValidity();
      }

      return;
    }

    this.loading = true;

    const email = this.email.value;
    const emailConfirmation = this.emailConfirmation.value;

    this.authFacade
      .sendEmailChangeToken(email, emailConfirmation)
      .subscribe(() => {
        this.loading = false;
        this.emailChangeForm.reset();
      });
  }
}
