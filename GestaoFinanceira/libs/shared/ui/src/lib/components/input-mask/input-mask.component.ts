import { Component, Input, forwardRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  ControlValueAccessor,
  FormControl,
  FormsModule,
  NG_VALUE_ACCESSOR,
  ReactiveFormsModule,
} from '@angular/forms';

import { FloatLabelModule } from 'primeng/floatlabel';
import { InputMaskModule } from 'primeng/inputmask';

@Component({
  selector: 'lib-input-mask',
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    FloatLabelModule,
    InputMaskModule,
  ],
  templateUrl: './input-mask.component.html',
  styleUrl: './input-mask.component.css',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputMaskComponent),
      multi: true,
    },
  ],
})
export class InputMaskComponent implements ControlValueAccessor {
  @Input() id = '';
  @Input() name = '';
  @Input() label = '';
  @Input() floatLabel = false;
  @Input() floatLabelType: 'in' | 'over' | 'on' = 'in';
  @Input() mask = '';
  @Input() control: FormControl = new FormControl();
  @Input() placeholder = '';
  @Input() disabled = false;
  @Input() required = false;
  @Input() readonly = false;
  @Input() autofocus = false;
  @Input() autocomplete: 'on' | 'off' = 'off';
  @Input() error = '';
  @Input() hint = '';
  @Input() hintName = '';
  @Input() variant: 'outlined' | 'filled' = 'outlined';
  @Input() fluid = false;
  @Input() size: 'small' | 'large' = 'small';
  @Input() minlength = 0;
  @Input() maxlength = 0;
  @Input() loading = false;

  onChange: any = () => undefined;
  onTouch: any = () => undefined;

  writeValue(value: any): void {
    this.control.setValue(value);
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouch = fn;
  }

  setDisabledState(isDisabled: boolean): void {
    if (isDisabled) {
      this.control.disable();
    } else {
      this.control.enable();
    }
  }

  onInput(event: any): void {
    this.onChange(event.target.value);
  }

  onBlur(): void {
    this.onTouch();
  }

  get hasError(): boolean {
    return this.control.invalid && (this.control.dirty || this.control.touched);
  }

  get errorMessage(): string {
    const error = Object.keys(this.control.errors || {})[0];

    if (error) {
      let message = errorMessages[error as keyof typeof errorMessages].replace(
        '{0}',
        this.hintName || this.label
      );

      if (error === 'minlength' || error === 'maxlength') {
        message = message
          .replace('{min}', this.minlength.toString())
          .replace('{max}', this.maxlength.toString());
      }

      return message;
    }

    return this.error;
  }
}

const errorMessages = {
  required: '{0} é obrigatório',
  email: 'E-mail inválido',
  number: 'Número inválido',
  minlength: '{0} deve ter no mínimo {min} caracteres',
  maxlength: '{0} deve ter no máximo {max} caracteres',
  phoneExists: 'Telefone já cadastrado',
};
