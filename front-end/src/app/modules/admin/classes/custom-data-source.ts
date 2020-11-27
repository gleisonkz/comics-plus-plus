import { CollectionViewer, DataSource } from '@angular/cdk/collections';
import { Observable, BehaviorSubject, of } from 'rxjs';
import { debounceTime, finalize } from 'rxjs/operators';
import { Filter } from '../../../models/filter.model';
import { HttpResponse } from '@angular/common/http';

export class CustomDataSource<T> implements DataSource<T> {
  private sourceSubject = new BehaviorSubject<T[]>([]);

  private loadingData = new BehaviorSubject<boolean>(false);

  public loading$ = this.loadingData.asObservable().pipe(debounceTime(200));

  constructor(
    private callbackService: (filter: Filter) => Observable<HttpResponse<T[]>>
  ) {}

  loadData(filter: Filter) {
    return new Observable<number>((publisher) => {
      this.loadingData.next(true);

      this.callbackService(filter)
        .pipe(
          // catchError(() => of([])),
          finalize(() => this.loadingData.next(false))
        )
        .subscribe((response: HttpResponse<T[]>) => {
          const pagination = JSON.parse(response.headers.get('x-pagination'));
          publisher.next(pagination);

          this.loadingData.next(false);
          return this.sourceSubject.next(response.body);
        });
    });
  }

  connect(collectionViewer: CollectionViewer): Observable<T[]> {
    return this.sourceSubject.asObservable();
  }

  disconnect(collectionViewer: CollectionViewer): void {
    this.sourceSubject.complete();
    this.loadingData.complete();
  }
}