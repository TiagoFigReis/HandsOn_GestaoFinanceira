import { Injectable } from '@angular/core';
import { catchError } from 'rxjs';
import { RequestService } from '../request/request.service';
import { Receita } from '../../models/receita.model';
import { HttpContext } from '@angular/common/http';
import { BYPASS_INTERCEPTORS } from '../../interceptors/authentication/authentication.interceptor';

@Injectable({
  providedIn: 'root',
})
export class ReceitaService extends RequestService {
  httpOptionsBypassInterceptor = {
    ...this.httpOptions,
    context: new HttpContext().set(BYPASS_INTERCEPTORS, true),
  };

  getAll() {
      return this.httpClient
        .get<Receita[]>(`${this.receitaApiUrl}`, this.httpOptions)
        .pipe(catchError(this.handleError));
  }

  getById(id: string) {
    return this.httpClient
      .get<Receita>(`${this.receitaApiUrl}/${id}`, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  create(receita: Receita) {
      return this.httpClient
        .post<Receita>(`${this.receitaApiUrl}`, JSON.stringify(receita), this.httpOptions)
        .pipe(catchError(this.handleError));
    }
  
  update(receita: Receita) {
      return this.httpClient
        .put<Receita>(
          `${this.usersApiUrl}/${receita.id}`,
          JSON.stringify(receita),
          this.httpOptions,
        )
        .pipe(catchError(this.handleError));
    }

    delete(id: string) {
      return this.httpClient
        .delete<void>(`${this.receitaApiUrl}/${id}`, this.httpOptions)
        .pipe(catchError(this.handleError));
    }
}