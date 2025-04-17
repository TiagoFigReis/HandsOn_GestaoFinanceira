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
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';
import { InputTextModule } from 'primeng/inputtext';

@Component({
  selector: 'lib-input-number',
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    FloatLabelModule,
    IconFieldModule,
    InputIconModule,
    InputTextModule,
  ],
  templateUrl: './input-number.component.html',
  styleUrl: './input-number.component.css',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputNumberComponent),
      multi: true,
    },
  ],
})
export class InputNumberComponent implements ControlValueAccessor {
  @Input() id = '';
  @Input() name = '';
  @Input() label = '';
  @Input() floatLabel = false;
  @Input() floatLabelType: 'in' | 'over' | 'on' = 'in';
  @Input() type = 'number';
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
  @Input() icon = '';
  @Input() iconPosition: 'left' | 'right' = 'left';
  @Input() min = 0;
  @Input() max = 0;
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
        this.hintName || this.label,
      );

        if (error === 'min' || error === 'max') {
          message = message
            .replace('{min}', this.min.toString())
            .replace('{max}', this.max.toString());
        }
      
      return message;
    }

    return this.error;
  }
}

const errorMessages = {
  required: '{0} é obrigatório',
  number: 'Número inválido',
  min: '{0} deve ser no mínimo {min}',
  max: '{0} deve ser no máximo {max}',
};
