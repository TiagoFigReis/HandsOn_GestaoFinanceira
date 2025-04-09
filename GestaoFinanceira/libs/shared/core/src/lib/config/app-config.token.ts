import { InjectionToken } from '@angular/core';
import { Environment } from '../models/environment.model';

export const APP_CONFIG = new InjectionToken<Environment>('Application config');
