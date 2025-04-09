import {
  AbstractControl,
  AsyncValidatorFn,
  ValidationErrors,
} from '@angular/forms';
import { Observable } from 'rxjs';

export function validateEmailExists(
  defaultValue: string,
  check: (email: string) => Observable<{ emailExists: boolean }>,
): AsyncValidatorFn {
  return async (control: AbstractControl): Promise<ValidationErrors | null> => {
    if (defaultValue && defaultValue === control.value) {
      return Promise.resolve(null);
    }

    const response = await check(control.value).toPromise();

    return response ? { emailExists: true } : null;
  };
}

export function validateEmailsMatch(
  controlName: string,
): (control: AbstractControl) => ValidationErrors | null {
  return (control: AbstractControl): ValidationErrors | null => {
    const emailControl = control.root.get(controlName);

    if (!emailControl) return null;

    if (control.value !== emailControl.value) {
      return { emailsMatch: true };
    }

    if (emailControl.errors && emailControl.errors['emailsMatch']) {
      delete emailControl.errors['emailsMatch'];

      if (!Object.keys(emailControl.errors).length) {
        emailControl.setErrors(null);
      }
    }

    return null;
  };
}

export function validatePhoneExists(
  defaultValue: string,
  check: (email: string) => Observable<{ phoneExists: boolean }>,
): AsyncValidatorFn {
  return async (control: AbstractControl): Promise<ValidationErrors | null> => {
    if (defaultValue && defaultValue === control.value) {
      return Promise.resolve(null);
    }

    const response = await check(control.value).toPromise();

    return response ? { phoneExists: true } : null;
  };
}

export function validatePasswordMatch(
  controlName: string,
): (control: AbstractControl) => ValidationErrors | null {
  return (control: AbstractControl): ValidationErrors | null => {
    const passwordControl = control.root.get(controlName);

    if (!passwordControl) return null;

    if (control.value !== passwordControl.value) {
      return { passwordMatch: true };
    }

    if (passwordControl.errors && passwordControl.errors['passwordMatch']) {
      delete passwordControl.errors['passwordMatch'];

      if (!Object.keys(passwordControl.errors).length) {
        passwordControl.setErrors(null);
      }
    }

    return null;
  };
}
