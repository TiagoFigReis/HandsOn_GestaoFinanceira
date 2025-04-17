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
  Despesa,
  DespesaFacade,
  Categories,
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
export class DespesaFormComponent implements OnInit, OnChanges {
  @Input() despesa: Despesa | undefined;
  @Input() loading = false;
  @Input() submitLabel = 'Adicionar';

  @Output() despesaSubmit = new EventEmitter<Despesa>();
  sourceOptions: SelectOption[] = [
    { value: '0', label: 'Despesa Fixa' },
    { value: '1', label: 'Despesa Variável' },
    { value: '2', label: 'Despesa Ocasional' },
    { value: '3', label: 'Despesa Emergencial' },
    { value: '4', label: 'Despesa Financeira' },
    { value: '5', label: 'Outros' },
  ];

  despesaForm: FormGroup;
}