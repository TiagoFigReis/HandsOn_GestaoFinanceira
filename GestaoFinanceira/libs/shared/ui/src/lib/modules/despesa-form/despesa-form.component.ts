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
  Despesa,
} from '@farm/core';
import { InputNumberComponent } from '../../components/input-number/input-number.component';
import { UploadFileComponent } from '../../components/uploadFile/uploadFile.component';

@Component({
  selector: 'lib-despesa-form',
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    InputComponent,
    UploadFileComponent,
    InputNumberComponent,
    ButtonComponent,
    SelectComponent,
  ],
  templateUrl: './despesa-form.component.html',
  styleUrl: './despesa-form.component.css',
})
export class DespesaFormComponent implements OnChanges {
  @Input() despesa: Despesa | undefined;
  @Input() loading = false;
  @Input() submitLabel = 'Adicionar';

  @Output() despesaSubmit = new EventEmitter<Despesa>();

  despesaForm: FormGroup;
  sourceOptions: SelectOption[] = [
    { value: '0', label: 'Despesa Fixa' },
    { value: '1', label: 'Despesa Variável' },
    { value: '2', label: 'Despesa Ocasional' },
    { value: '3', label: 'Despesa Emergencial' },
    { value: '4', label: 'Outros' },
  ];

  maxValue = Number.MAX_VALUE;
  
  constructor() {
    this.despesaForm = new FormGroup({
      categoria: new FormControl('', { validators: [
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
      }),
      file: new FormControl('', {
        updateOn: 'blur'
      })
    })
  }

  ngOnChanges(): void {
    if (this.despesa) this.updateDespesaData();

    if (this.loading) this.despesaForm.disable();
    else this.despesaForm.enable();
  }

  get categoria(): FormControl {
    return this.despesaForm.get('categoria') as FormControl;
  }

  get valor(): FormControl {
    return this.despesaForm.get('valor') as FormControl;
  }

  get descricao(): FormControl {
    return this.despesaForm.get('descricao') as FormControl;
  }

  get data(): FormControl {
    return this.despesaForm.get('data') as FormControl;
  }

  get file(): FormControl{
    return this.despesaForm.get('file') as FormControl
  }

  updateDespesaData(): void {
    if (!this.despesa) return;
    
    let categoria = null;
    
    if (this.despesa.categoria !== undefined) {
      const categoriaName = this.despesa.categoria;
      categoria = this.sourceOptions.find((option) => option.label === categoriaName);
    }
    
    this.despesaForm.patchValue({
      valor: this.despesa.valor,
      descricao: this.despesa.descricao,
      data: this.despesa.data.split('T')[0],
      categoria: categoria,
      file: this.despesa.comprovante
    });
  }

  onSubmit() {
      if (this.despesaForm.invalid) {
        return this.despesaForm.markAllAsTouched();
      }

      const despesa: Despesa = {
        id: this.despesa?.id,
        valor: this.valor.value,
        descricao: this.descricao.value,
        data: this.data.value
      };
  
      const categoria = this.categoria.value;

      const file = this.file
  
      if (categoria && categoria.label) despesa.categoria = categoria.label

      if(file && file.value) despesa.comprovante = file.value
  
      this.despesaSubmit.emit(despesa);
    }
}

export interface DespesaForm {
  categoria?: string;
  valor: number;
  descricao: string;
  data: string;
  comprovante?: File | string
  role?: string;
}