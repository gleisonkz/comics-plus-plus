import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Observable, ReplaySubject, Subject, Subscription } from 'rxjs';
import {
  debounceTime,
  distinctUntilChanged,
  filter,
  takeUntil
} from 'rxjs/operators';

@Component({
  selector: 'cms-dropdown-list',
  templateUrl: './dropdown-list.component.html',
  styleUrls: ['./dropdown-list.component.scss']
})
export class DropdownListComponent implements OnInit {
  dataList: any[] = [];

  isMatSelectClosing: boolean;
  _onDestroy = new Subject<void>();
  dataSearchControl: FormControl = new FormControl();
  filteredDataOptions$: ReplaySubject<any[]> = new ReplaySubject<any[]>(1);
  private subscriptions: Subscription[] = [];

  @Input() isNew: boolean;
  @Input() idKeyObject: string;
  @Input() valueKeyObject: string;
  @Input() placeholder: string;
  @Input() dataControl: FormControl;
  @Input() getFilteredDataCallback: (searchTerm: string) => Observable<any[]>;
  @Input() getInitialDataCallback: () => Observable<any[]>;

  constructor() {}

  ngOnInit(): void {
    this.getData();

    /** Escutando as alterações do campo de pesquisa*/
    this.dataSearchControl.valueChanges
      .pipe(
        takeUntil(this._onDestroy),
        debounceTime(500),
        filter((c) => c.length > 2 || c.length === 0),
        distinctUntilChanged()
      )
      .subscribe(() => {
        this.filterData();
      });
  }

  ngOnDestroy() {
    this._onDestroy.next();
    this._onDestroy.complete();
    this.subscriptions.forEach((c) => c.unsubscribe());
  }

  getData() {
    if (!this.isNew) {
      this.subscriptions.push(
        this.getInitialDataCallback().subscribe((responseData) => {
          this.dataList = responseData;

          this.dataControl.setValue(
            responseData.map((c) => c[this.idKeyObject])
          );
          this.filteredDataOptions$.next(this.dataList);
        })
      );
    }
  }

  filterData() {
    if (!this.dataList) {
      return;
    }
    // recuperando o termo de pesquisa

    let searchTerm = this.dataSearchControl.value;
    if (!searchTerm) {
      const previousSelectedData = this.dataList.filter((c) => {
        return this.dataControl.value.indexOf(c[this.idKeyObject]) !== -1;
      });
      this.filteredDataOptions$.next(previousSelectedData);
      return;
    } else {
      searchTerm = searchTerm.toLowerCase();
    }

    // Buscando os autores de acordo com o termo

    this.getFilteredDataCallback(searchTerm).subscribe((dataList) => {
      const previousSelectedData = this.dataList.filter(
        (c) => this.dataControl.value.indexOf(c[this.idKeyObject]) !== -1
      );
      this.dataList = [...previousSelectedData, ...dataList].reduce(
        (acc, cur) => {
          if (!acc.find((c) => c[this.idKeyObject] === cur[this.idKeyObject])) {
            acc.push(cur);
          }
          return acc;
        },
        []
      );
      this.filteredDataOptions$.next(this.dataList);
    });
  }

  openedChange(opening: boolean) {
    // Atualiza a lista de valores selecionados quando o dropdown for fechado
    if (!opening) {
      const previousSelectedData = this.dataList.filter((c) => {
        return this.dataControl.value.indexOf(c[this.idKeyObject]) !== -1;
      });
      this.filteredDataOptions$.next(previousSelectedData);
    }
  }

  getFormControlName(control: AbstractControl): string | null {
    let group = <FormGroup>control.parent;

    if (!group) {
      return null;
    }

    let name: string;

    Object.keys(group.controls).forEach((key) => {
      let childControl = group.get(key);

      if (childControl !== control) {
        return;
      }

      name = key;
    });

    return name;
  }
}
