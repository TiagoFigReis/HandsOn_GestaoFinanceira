import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { User } from '../models/user.model';
import { AuthenticationService } from '../services/authentication/authentication.service';
import { DespesaService } from '../services/despesa/despesa.service';
import { NotificationService } from '../services/notification/notification.service';

@Injectable({
  providedIn: 'root',
})
export class DespesaFacade {

}