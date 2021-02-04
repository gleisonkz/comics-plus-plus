import { Filter } from '@admin/models';
import { CollectionViewer, DataSource } from '@angular/cdk/collections';
import { HttpResponse } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { Pagination } from '../models/pagination.model';

export interface ICustomDataSource {
  loading$: Observable<boolean>;
}

export class CustomDataSource<TListModel, TFilterProps> implements DataSource<TListModel>, ICustomDataSource {
  private sourceSubject$$ = new BehaviorSubject<TListModel[]>([]);
  private loadingData$$ = new BehaviorSubject<boolean>(false);
  public loading$ = this.loadingData$$.asObservable();

  constructor(
    private callbackService: (filter: Filter<TFilterProps>) => Observable<HttpResponse<TListModel[]>>
  ) {}

  loadData(filter: Filter<TFilterProps>) {
    return new Observable<Pagination>((publisher) => {
      this.loadingData$$.next(true);

      this.callbackService(filter)
        .pipe(finalize(() => this.loadingData$$.next(false)))
        .subscribe((response: HttpResponse<TListModel[]>) => {
          const pagination = JSON.parse(response.headers.get('x-pagination')) as Pagination;
          publisher.next(pagination);
          publisher.complete();
          this.loadingData$$.next(false);
          return this.sourceSubject$$.next(response.body);
        });
    });
  }

  connect(_: CollectionViewer): Observable<TListModel[]> {
    return this.sourceSubject$$.asObservable();
  }

  disconnect(_: CollectionViewer): void {
    this.sourceSubject$$.complete();
    this.loadingData$$.complete();
  }
}
