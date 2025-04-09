import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthenticationInterceptor } from './lib/interceptors/authentication/authentication.interceptor';

// config
export * from './lib/config/app-config.token';

// models
export * from './lib/models/environment.model';
export * from './lib/models/token.model';
export * from './lib/models/user.model';

// services
export * from './lib/services/authentication/authentication.service';
export * from './lib/services/confirmation/confirmation.service';
export * from './lib/services/notification/notification.service';
export * from './lib/services/request/request.service';
export * from './lib/services/user/user.service';

// facades
export * from './lib/facades/auth.facade';
export * from './lib/facades/user.facade';

// guards
export * from './lib/guards/authenticated/authenticated.guard';
export * from './lib/guards/is-admin/is-admin.guard';

// interceptors
export const interceptorsProviders = [
  {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthenticationInterceptor,
    multi: true,
  },
];

export { BYPASS_INTERCEPTORS } from './lib/interceptors/authentication/authentication.interceptor';

// utils
export * from './lib/utils/form-validators';

// enums
export * from './lib/enums/user-roles.enum';
export * from './lib/enums/user-status.enum';
