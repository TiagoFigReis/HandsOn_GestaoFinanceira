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
    const formData = new FormData();
  
    formData.append('valor', receita.valor.toString());
    formData.append('descricao', receita.descricao);
    formData.append('data', receita.data);
  
    // Se fonte existir, converte pra string
    if (receita.fonte !== undefined && receita.fonte !== null) {
      formData.append('fonte', receita.fonte.toString());
    }
  
    // Se o arquivo estiver presente
    if (receita.comprovante) {
      formData.append('Comprovante', receita.comprovante);
    }
  
    return this.httpClient
      .post<Receita>(`${this.receitaApiUrl}`, formData)
      .pipe(catchError(this.handleError));
  }
  
  update(receita: Receita) {
    const formData = new FormData();

    formData.append('valor', receita.valor.toString());
    formData.append('descricao', receita.descricao);
    formData.append('data', receita.data);

    if (receita.fonte !== undefined && receita.fonte !== null) {
        formData.append('fonte', receita.fonte.toString());
    }

    if (receita.comprovante) {
        formData.append('Comprovante', receita.comprovante);
    }

    return this.httpClient
        .put<Receita>(`${this.receitaApiUrl}/${receita.id}`, formData)
        .pipe(catchError(this.handleError));
}

    delete(id: string) {
      return this.httpClient
        .delete<void>(`${this.receitaApiUrl}/${id}`, this.httpOptions)
        .pipe(catchError(this.handleError));
    }
}