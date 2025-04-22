import { Component, forwardRef, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FileUploadModule, FileUploadHandlerEvent } from 'primeng/fileupload';
import { ControlValueAccessor, FormControl, NG_VALUE_ACCESSOR } from '@angular/forms';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'lib-upload-file',
  imports: [CommonModule, FileUploadModule, ButtonModule],
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
  @Input() maxFileSize = '1000000'
  @Input() auto = false
  @Input() control: FormControl = new FormControl();

  fileName = '';
  filePreview = '';

  onChange: any = () => undefined;
  onTouch: any = () => undefined;

  writeValue(value: any): void {
    this.createImagePreview(value)
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouch = fn;
  }

  onFileSelect(event: FileUploadHandlerEvent) {
    const file = event.files?.[0];
    this.fileName = event.files?.[0].name

    if(file){
      this.control.setValue(file)
      this.control.markAsTouched();
      this.control.markAsDirty();
    }

    this.createImagePreview(file);
  }

  createImagePreview(input: File | string): void {
    if (typeof input === 'string' && input) {
      this.fileName = "Comprovante.png"
      this.filePreview = input;
    } else if (input instanceof File) {
      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.filePreview = e.target.result;
      };
      reader.readAsDataURL(input);
    }
  }

  removeFile(): void {
    
    this.fileName = '';
    this.filePreview = '';

    this.control.setValue(null);
    this.control.markAsTouched();
    this.control.markAsDirty();
  }
}
