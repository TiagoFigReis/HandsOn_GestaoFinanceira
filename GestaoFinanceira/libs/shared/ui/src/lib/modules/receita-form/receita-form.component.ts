import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
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
import {
  SelectComponent,
  SelectOption,
} from '../../components/select/select.component';
import {
  Receita,
  Sources,
} from '@farm/core';
import { InputNumberComponent } from '../../components/input-number/input-number.component';

@Component({
  selector: 'lib-receita-form',
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    InputComponent,
    InputNumberComponent,
    ButtonComponent,
    SelectComponent,
  ],
  templateUrl: './receita-form.component.html',
  styleUrl: './receita-form.component.css',
})
export class ReceitaFormComponent implements OnChanges {
  @Input() receita: Receita | undefined;
  @Input() loading = false;
  @Input() submitLabel = 'Adicionar';

  @Output() receitaSubmit = new EventEmitter<Receita>();

  receitaForm: FormGroup;
  sourceOptions: SelectOption[] = [
    { value: '0', label: 'Renda Ativa' },
    { value: '1', label: 'Renda Passiva' },
    { value: '2', label: 'Renda Variável' },
    { value: '3', label: 'Renda Extra' },
    { value: '4', label: 'Outros' },
  ];

  maxValue = Number.MAX_VALUE;
  
  constructor() {
    this.receitaForm = new FormGroup({
      fonte: new FormControl('', { validators: [
        Validators.required
      ], updateOn: 'blur' }),
      valor: new FormControl('', {
        validators: [
          Validators.required,
          Validators.min(0.01),
          Validators.max(this.maxValue),
        ],
        updateOn: 'blur'}),
      descricao: new FormControl('', {
        validators: [
          Validators.required,
          Validators.minLength(1),
          Validators.maxLength(50)
        ],
        updateOn: 'blur'
      }),
      data: new FormControl('', {
        validators: [
          Validators.required
        ],
        updateOn: 'blur'
      })
    })
  }

  ngOnChanges(): void {
    if (this.receita) this.updateReceitaData();

    if (this.loading) this.receitaForm.disable();
    else this.receitaForm.enable();
  }

  get fonte(): FormControl {
    return this.receitaForm.get('fonte') as FormControl;
  }

  get valor(): FormControl {
    return this.receitaForm.get('valor') as FormControl;
  }

  get descricao(): FormControl {
    return this.receitaForm.get('descricao') as FormControl;
  }

  get data(): FormControl {
    return this.receitaForm.get('data') as FormControl;
  }

  updateReceitaData(): void {
    if (!this.receita) return;
    
    let fonte = null;
    
    if (this.receita.fonte !== undefined) {
      const fonteName = Sources[this.receita.fonte as keyof typeof Sources];
      fonte = this.sourceOptions.find((option) => option.label === fonteName);
    }
    
    this.receitaForm.patchValue({
      valor: this.receita.valor,
      descricao: this.receita.descricao,
      data: this.receita.data,
      fonte: fonte,
    });
  }

  onSubmit() {
      if (this.receitaForm.invalid) {
        return this.receitaForm.markAllAsTouched();
      }

      const date = new Date(this.data.value)

      date.setHours(new Date().getHours() - 3)
      date.setMinutes(new Date().getMinutes());
      date.setSeconds(new Date().getSeconds());
      date.setMilliseconds(new Date().getMilliseconds());

      const receita: Receita = {
        id: this.receita?.id,
        valor: this.valor.value,
        descricao: this.descricao.value,
        data: date.toISOString()
      };
  
      const fonte = this.fonte.value;
  
      if (fonte && fonte.value) receita.fonte = parseInt(fonte.value);
  
      this.receitaSubmit.emit(receita);
    }
}

export interface ReceitaForm {
  fonte?: string;
  valor: number;
  descricao: string;
  data: string;
  role?: string;
}