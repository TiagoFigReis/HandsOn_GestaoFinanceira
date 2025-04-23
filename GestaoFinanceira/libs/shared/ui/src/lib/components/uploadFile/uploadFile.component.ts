import { Component, forwardRef, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FileUploadModule, FileUploadHandlerEvent } from 'primeng/fileupload';
import { ControlValueAccessor, FormControl, FormsModule, NG_VALUE_ACCESSOR, ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'lib-upload-file',
  imports: [CommonModule, FormsModule, ReactiveFormsModule, FileUploadModule, ButtonModule],
  templateUrl: './uploadFile.component.html',
  styleUrl: './uploadFile.component.css',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => UploadFileComponent),
      multi: true,
    }
  ]
})
export class UploadFileComponent implements ControlValueAccessor{
  
  @Input() mode: 'basic' | 'advanced' = 'basic'
  @Input() chooseLabel = ''
  @Input() chooseIcon = "pi pi-upload"
  @Input() name = ''
  @Input() url = ''
  @Input() accept = '.png,.jpg,.jpeg'
  @Input() maxFileSize = '1000000000'
  @Input() auto = false

  fileName = '';
  filePreview = '';

  onChange: any = () => undefined;
  onTouch: any = () => undefined;

  writeValue(value: any): void {
    if(value){
      this.loadImageAsFile(value, "Comprovante")
    }
    
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouch = fn;
  }

  async loadImageAsFile(url: string, fileName: string): Promise<void> {
    try {
      const response = await fetch(url);
      const blob = await response.blob();
      const ext = blob.type.split('/')[1];
      const file = new File([blob], `Comprovante.${ext}`, { type: blob.type });
      this.onChange(file);  
      this.onTouch(); 
      this.createImagePreview(file);
      this.fileName = `${fileName}.${ext}`;
    } catch (error) {
      console.error('Erro ao carregar imagem como File:', error);
    }
  }

  onFileSelect(event: FileUploadHandlerEvent) {
    const file = event.files?.[0];
    if(file){
      this.onChange(file); 
      this.onTouch(); 
      this.createImagePreview(file);
      this.fileName = event.files?.[0].name
    }
  }

  createImagePreview(input: File): void {
      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.filePreview = e.target.result;
      };
      reader.readAsDataURL(input);
  }

  removeFile(): void {
    
    this.fileName = '';
    this.filePreview = '';

    this.onChange(null);  
    this.onTouch(); 

  }
}
