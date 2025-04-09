import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ButtonComponent } from '../../components/button/button.component';
import { InputComponent } from '../../components/input/input.component';
import { InputMaskComponent } from '../../components/input-mask/input-mask.component';
import { InputPasswordComponent } from '../../components/input-password/input-password.component';
import {
  SelectComponent,
  SelectOption,
} from '../../components/select/select.component';
import {
  User,
  UserFacade,
  UserRoles,
  validateEmailExists,
  validatePhoneExists,
} from '@farm/core';

@Component({
  selector: 'lib-user-form',
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    InputComponent,
    InputMaskComponent,
    InputPasswordComponent,
    ButtonComponent,
    SelectComponent,
  ],
  templateUrl: './user-form.component.html',
  styleUrl: './user-form.component.css',
})
export class UserFormComponent implements OnInit, OnChanges {
  @Input() user: User | undefined;
  @Input() selectRole = false;
  @Input() showPassword = false;
  @Input() loading = false;
  @Input() emailValidating = true;
  @Input() phoneValidating = true;
  @Input() submitLabel = 'Cadastrar';

  @Output() userSubmit = new EventEmitter<User>();

  userForm: FormGroup;
  roleOptions: SelectOption[] = [
    { value: '0', label: 'Admin' },
    { value: '1', label: 'Proprietário' },
    { value: '2', label: 'Consultor' },
    { value: '3', label: 'Gerente' },
    { value: '4', label: 'Colaborador' },
  ];

  constructor(private userFacade: UserFacade) {
    this.userForm = new FormGroup({
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
      email: new FormControl('', {
        validators: [Validators.required, Validators.email],
        asyncValidators: [
          validateEmailExists(
            '',
            this.userFacade.checkEmail.bind(this.userFacade),
          ),
        ],
        updateOn: 'blur',
      }),
      phone: new FormControl('', {
        validators: [Validators.required, Validators.maxLength(15)],
        asyncValidators: [
          validatePhoneExists(
            '',
            this.userFacade.checkPhone.bind(this.userFacade),
          ),
        ],
        updateOn: 'blur',
      }),
      password: new FormControl('', { validators: [], updateOn: 'blur' }),
      role: new FormControl('', { validators: [], updateOn: 'blur' }),
    });
  }

  ngOnInit(): void {
    if (this.selectRole) this.role.setValidators([Validators.required]);

    if (this.showPassword)
      this.password.setValidators([
        Validators.required,
        Validators.minLength(8),
        Validators.maxLength(18),
        Validators.pattern(
          /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,18}$/,
        ),
      ]);

    if (this.user) this.updateUserData();
  }

  ngOnChanges(): void {
    if (this.user) this.updateUserData();

    if (this.loading) this.userForm.disable();
    else this.userForm.enable();
  }

  get firstName(): FormControl {
    return this.userForm.get('firstName') as FormControl;
  }

  get lastName(): FormControl {
    return this.userForm.get('lastName') as FormControl;
  }

  get email(): FormControl {
    return this.userForm.get('email') as FormControl;
  }

  get phone(): FormControl {
    return this.userForm.get('phone') as FormControl;
  }

  get password(): FormControl {
    return this.userForm.get('password') as FormControl;
  }

  get role(): FormControl {
    return this.userForm.get('role') as FormControl;
  }

  updateUserData(): void {
    if (!this.user) return;

    let role = null;

    if (this.user.role !== undefined) {
      const roleName = UserRoles[this.user.role as keyof typeof UserRoles];
      role = this.roleOptions.find((option) => option.label === roleName);
    }

    this.userForm.patchValue({
      firstName: this.user.firstName,
      lastName: this.user.lastName,
      email: this.user.email,
      phone: this.user.phoneNumber,
      role: role,
    });

    if (this.emailValidating)
      this.email.setAsyncValidators([
        validateEmailExists(
          this.user.email,
          this.userFacade.checkEmail.bind(this.userFacade),
        ),
      ]);

    if (this.phoneValidating)
      this.phone.setAsyncValidators([
        validatePhoneExists(
          this.user.phoneNumber,
          this.userFacade.checkPhone.bind(this.userFacade),
        ),
      ]);
  }

  onSubmit() {
    if (this.userForm.invalid) {
      return this.userForm.markAllAsTouched();
    }

    const user: User = {
      id: this.user?.id,
      firstName: this.firstName.value,
      lastName: this.lastName.value,
      email: this.email.value,
      phoneNumber: this.phone.value,
      password: this.password.value,
    };

    const role = this.role.value;

    if (role && role.value) user.role = parseInt(role.value);

    this.userSubmit.emit(user);
  }
}

export interface UserForm {
  firstName: string;
  lastName: string;
  email: string;
  phone: string;
  password: string;
  role?: string;
}
