import { Filter } from '@admin/models';
import { CollectionViewer, DataSource } from '@angular/cdk/collections';
import { HttpResponse } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { debounceTime, finalize } from 'rxjs/operators';
import { Pagination } from './../models/x-pagination.model';

export class CustomDataSource<T> implements DataSource<T> {
  private sourceSubject = new BehaviorSubject<T[]>([]);
  private loadingData = new BehaviorSubject<boolean>(false);
  public loading$ = this.loadingData.asObservable().pipe(debounceTime(200));

  constructor(
    private callbackService: (filter: Filter) => Observable<HttpResponse<T[]>>
  ) {}

  loadData(filter: Filter) {
    return new Observable<Pagination>((publisher) => {
      this.loadingData.next(true);

      this.callbackService(filter)
        .pipe(finalize(() => this.loadingData.next(false)))
        .subscribe((response: HttpResponse<T[]>) => {
          const pagination = JSON.parse(
            response.headers.get('x-pagination')
          ) as Pagination;
          publisher.next(pagination);
          this.loadingData.next(false);
          return this.sourceSubject.next(response.body);
        });
    });
  }

  connect(_: CollectionViewer): Observable<T[]> {
    return this.sourceSubject.asObservable();
  }

  disconnect(_: CollectionViewer): void {
    this.sourceSubject.complete();
    this.loadingData.complete();
  }
}
