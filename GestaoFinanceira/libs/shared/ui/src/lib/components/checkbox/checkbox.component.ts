import { Component, Input, forwardRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  ControlValueAccessor,
  FormControl,
  FormsModule,
  NG_VALUE_ACCESSOR,
  ReactiveFormsModule,
} from '@angular/forms';
import { CheckboxModule } from 'primeng/checkbox';

@Component({
  selector: 'lib-checkbox',
  imports: [CommonModule, CheckboxModule, FormsModule, ReactiveFormsModule],
  templateUrl: './checkbox.component.html',
  styleUrl: './checkbox.component.css',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => CheckboxComponent),
      multi: true,
    },
  ],
})
export class CheckboxComponent implements ControlValueAccessor {
  @Input() id = '';
  @Input() name = '';
  @Input() label = '';
  @Input() value: any = '';
  @Input() binary = true;
  @Input() control: FormControl = new FormControl();
  @Input() disabled = false;
  @Input() required = false;
  @Input() readonly = false;
  @Input() autofocus = false;
  @Input() error = '';
  @Input() variant: 'outlined' | 'filled' = 'outlined';
  @Input() size: 'small' | 'large' = 'small';
  @Input() checkboxIcon = '';

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

  get hasError(): boolean {
    return this.control.invalid && (this.control.dirty || this.control.touched);
  }

  get errorMessage(): string {
    const error = Object.keys(this.control.errors || {})[0];

    if (error) {
      const message = errorMessages[
        error as keyof typeof errorMessages
      ].replace('{0}', this.label);

      return message;
    }

    return this.error;
  }
}

const errorMessages = {
  required: '{0} é obrigatório',
};
