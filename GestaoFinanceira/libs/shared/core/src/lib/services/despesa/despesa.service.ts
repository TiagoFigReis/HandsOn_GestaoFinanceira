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
      return this.httpClient
        .post<Despesa>(`${this.despesaApiUrl}`, JSON.stringify(despesa), this.httpOptions)
        .pipe(catchError(this.handleError));
    }
  
  update(despesa: Despesa) {
      return this.httpClient
        .put<Despesa>(
          `${this.despesaApiUrl}/${despesa.id}`,
          JSON.stringify(despesa),
          this.httpOptions,
        )
        .pipe(catchError(this.handleError));
    }

    delete(id: string) {
      return this.httpClient
        .delete<void>(`${this.despesaApiUrl}/${id}`, this.httpOptions)
        .pipe(catchError(this.handleError));
    }
}