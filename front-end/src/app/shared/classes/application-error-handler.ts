import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandler, Injectable, NgZone } from '@angular/core';
import { NotificationService } from '@core/services';
import HttpStatusCode from '@shared/enums/http-status-code.enum';

@Injectable()
export class ApplicationErrorHandler extends ErrorHandler {
  constructor(
    private notificationService: NotificationService,

    private zone: NgZone
  ) {
    super();
  }

  handleError(errorResponse: HttpErrorResponse | any) {
    if (errorResponse instanceof HttpErrorResponse) {
      const message = errorResponse?.error;

      this.zone.run(() => {
        switch (errorResponse.status) {
          case HttpStatusCode.BAD_REQUEST:
            this.notificationService.showMessage(
              message || 'Houve erro na validação dos dados.',
              ''
            );
            break;
          case HttpStatusCode.UNAUTHORIZED:
            this.notificationService.showMessage(
              message || 'Não autorizado.',
              ''
            );
            break;
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
          case HttpStatusCode.METHOD_NOT_ALLOWED:
            this.notificationService.showMessage(
              message ||
                'Método não permitido. Verifique o console para mais detalhes.',
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
