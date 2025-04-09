import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ButtonComponent, InputComponent, InputMaskComponent } from '@farm/ui';
import {
  User,
  UserFacade,
  validatePhoneExists,
  ConfirmationService,
} from '@farm/core';

@Component({
  selector: 'lib-account',
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ButtonComponent,
    InputComponent,
    InputMaskComponent,
  ],
  templateUrl: './account.component.html',
  styleUrl: './account.component.css',
})
export class AccountComponent implements OnInit {
  user: User | undefined;
  accountForm: FormGroup;
  loading = false;

  constructor(
    private userFacade: UserFacade,
    private confirmationService: ConfirmationService,
  ) {
    this.accountForm = new FormGroup({
      firstName: new FormControl('', {
        validators: [
          Validators.required,
          Validators.minLength(2),
          Validators.maxLength(50),
        ],
        updateOn: 'blur',
      }),
      lastName: new FormControl('', {
        validators: [
          Validators.required,
          Validators.minLength(2),
          Validators.maxLength(50),
        ],
        updateOn: 'blur',
      }),
      phone: new FormControl('', {
        validators: [Validators.required, Validators.maxLength(15)],
        updateOn: 'blur',
      }),
    });
  }

  ngOnInit() {
    this.userFacade.user$.subscribe((user) => {
      if (!user) return;

      this.user = user;

      this.firstName.setValue(user.firstName);
      this.lastName.setValue(user.lastName);
      this.phone.setValue(user.phoneNumber);

      this.phone.setAsyncValidators(
        validatePhoneExists(
          this.user.phoneNumber || '',
          this.userFacade.checkPhone.bind(this.userFacade),
        ),
      );
    });
  }

  get firstName(): FormControl {
    return this.accountForm.get('firstName') as FormControl;
  }

  get lastName(): FormControl {
    return this.accountForm.get('lastName') as FormControl;
  }

  get phone(): FormControl {
    return this.accountForm.get('phone') as FormControl;
  }

  onSubmit() {
    if (this.accountForm.invalid) return;

    this.accountForm.markAllAsTouched();

    return this.confirmationService.confirm({
      message: 'Você tem certeza que deseja alterar seus dados?',
      accept: () => {
        this.updateUser();
      },
    });
  }

  updateUser() {
    if (!this.user) return;

    const userUpdated: User = {
      ...this.user,
      firstName: this.firstName.value,
      lastName: this.lastName.value,
      phoneNumber: this.phone.value,
    };

    this.phone.clearAsyncValidators();
    this.loading = true;

    this.userFacade.updateMe(userUpdated).subscribe(
      () => {
        this.loading = false;
      },
      () => {
        this.loading = false;
      },
    );
  }
}
