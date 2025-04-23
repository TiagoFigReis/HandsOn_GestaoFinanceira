import { Injectable } from '@angular/core';
import { catchError } from 'rxjs';
import { RequestService } from '../request/request.service';
import { HttpContext } from '@angular/common/http';
import { BYPASS_INTERCEPTORS } from '../../interceptors/authentication/authentication.interceptor';
import { Despesa } from '../../models/despesa.model';

@Injectable({
  providedIn: 'root',
})
export class DespesaService extends RequestService {
  httpOptionsBypassInterceptor = {
    ...this.httpOptions,
    context: new HttpContext().set(BYPASS_INTERCEPTORS, true),
  };

  getAll() {
      return this.httpClient
        .get<Despesa[]>(`${this.despesaApiUrl}`, this.httpOptions)
        .pipe(catchError(this.handleError));
  }

  getById(id: string) {
    return this.httpClient
      .get<Despesa>(`${this.despesaApiUrl}/${id}`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  create(despesa: Despesa) {
      const formData = new FormData();
    
      formData.append('valor', despesa.valor.toString());
      formData.append('descricao', despesa.descricao);
      formData.append('data', despesa.data);
    
      
      if (despesa.categoria !== undefined && despesa.categoria !== null) {
        formData.append('categoria', despesa.categoria.toString());
      }
    
      
      if (despesa.comprovante) {
        formData.append('Comprovante', despesa.comprovante);
      }
    
      return this.httpClient
        .post<Despesa>(`${this.despesaApiUrl}`, formData)
        .pipe(catchError(this.handleError));
    }
  
   update(despesa: Despesa) {
      const formData = new FormData();
  
      formData.append('valor', despesa.valor.toString());
      formData.append('descricao', despesa.descricao);
      formData.append('data', despesa.data);
  
      if (despesa.categoria !== undefined && despesa.categoria !== null) {
          formData.append('categoria', despesa.categoria.toString());
      }
  
      if (despesa.comprovante) {
          formData.append('Comprovante', despesa.comprovante);
      }
  
      return this.httpClient
          .put<Despesa>(`${this.despesaApiUrl}/${despesa.id}`, formData)
          .pipe(catchError(this.handleError));
    }

    delete(id: string) {
      return this.httpClient
        .delete<void>(`${this.despesaApiUrl}/${id}`, this.httpOptions)
        .pipe(catchError(this.handleError));
    }
}