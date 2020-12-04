import { Injector, NgZone } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';

import { ErrorHandler, Inject, Injectable } from '@angular/core';

// import { LoginService } from './services/login.service';
import { NotificationService } from '../services/notification.service';
import HttpStatusCode from '../enums/http-status-code.enum';

@Injectable()
export class ApplicationErrorHandler extends ErrorHandler {
  constructor(
    private notificationService: NotificationService,
    private injector: Injector,
    private zone: NgZone
  ) {
    super();
  }

  handleError(errorResponse: HttpErrorResponse | any) {
    if (errorResponse instanceof HttpErrorResponse) {
      const message = errorResponse?.error?.message;
      this.zone.run(() => {
        switch (errorResponse.status) {
          case HttpStatusCode.BAD_REQUEST:
            this.notificationService.showMessage(
              message || 'Houve erro na validação dos dados.',
              ''
            );
            break;
          case HttpStatusCode.UNAUTHORIZED:
            // this.injector.get(LoginService).handleLogin();
            break;
          case HttpStatusCode.FORBIDDEN:
            this.notificationService.showMessage(
              message || 'Não autorizado.',
              ''
            );
            break;
          case HttpStatusCode.NOT_FOUND:
            this.notificationService.showMessage(
              message ||
                'Recurso não encontrado. Verifique o console para mais detalhes.',
              ''
            );
            break;
          default:
            this.notificationService.showMessage(
              'Houve erro ao conectar no servidor.',
              ''
            );
            break;
        }
      });
    }

    super.handleError(errorResponse);
  }
}
