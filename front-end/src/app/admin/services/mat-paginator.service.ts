import { Injectable } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';

@Injectable({
  providedIn: 'root'
})
export class MatPaginatorService {
  constructor() {}

  applyGlobalization(paginator: MatPaginator) {
    paginator._intl.firstPageLabel = 'Primeira Página';
    paginator._intl.lastPageLabel = 'Última Página';
    paginator._intl.nextPageLabel = 'Próxima Página';
    paginator._intl.previousPageLabel = 'Página Anterior';
    paginator._intl.itemsPerPageLabel = 'Itens por página';
    paginator._intl.getRangeLabel = function (page, pageSize, length) {
      if (length === 0 || pageSize === 0) {
        return '1 de ' + length;
      }
      length = Math.max(length, 0);
      const startIndex = page * pageSize;
      const endIndex =
        startIndex < length
          ? Math.min(startIndex + pageSize, length)
          : startIndex + pageSize;
      return startIndex + 1 + ' - ' + endIndex + ' de ' + length;
    };
  }
}
