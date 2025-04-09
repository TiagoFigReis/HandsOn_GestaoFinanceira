import { Component, Input, forwardRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SelectModule } from 'primeng/select';
import {
  ControlValueAccessor,
  FormControl,
  FormsModule,
  NG_VALUE_ACCESSOR,
  ReactiveFormsModule,
} from '@angular/forms';
import { FloatLabel } from 'primeng/floatlabel';

@Component({
  selector: 'lib-select',
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    SelectModule,
    FloatLabel,
  ],
  templateUrl: './select.component.html',
  styleUrl: './select.component.css',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => SelectComponent),
      multi: true,
    },
  ],
})
export class SelectComponent implements ControlValueAccessor {
  @Input() id = '';
  @Input() name = '';
  @Input() label = '';
  @Input() floatLabel = false;
  @Input() floatLabelType: 'in' | 'over' | 'on' = 'in';
  @Input() control: FormControl = new FormControl();
  @Input() placeholder = '';
  @Input() disabled = false;
  @Input() required = false;
  @Input() readonly = false;
  @Input() autofocus = false;
  @Input() error = '';
  @Input() hint = '';
  @Input() hintName = '';
  @Input() variant: 'outlined' | 'filled' = 'outlined';
  @Input() fluid = false;
  @Input() size: 'small' | 'large' = 'small';
  @Input() loading = false;
  @Input() options: SelectOption[] = [];
  @Input() filter = false;
  @Input() filterBy = 'label';
  @Input() filterPlaceholder = '';
  @Input() filterMatchMode:
    | 'gt'
    | 'lt'
    | 'in'
    | 'startsWith'
    | 'contains'
    | 'endsWith'
    | 'equals'
    | 'notEquals'
    | 'lte'
    | 'gte' = 'contains';
  @Input() showClear = false;

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
      ].replace('{0}', this.hintName || this.label);

      return message;
    }

    return this.error;
  }
}

export interface SelectOption {
  label: string;
  value: string;
  image?: string;
}

const errorMessages = {
  required: '{0} é obrigatório',
};
