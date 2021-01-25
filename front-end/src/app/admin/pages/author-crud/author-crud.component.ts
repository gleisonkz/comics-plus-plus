import { CustomDataSource } from '@admin/classes/custom-data-source';
import {
  AuthorDialogComponent,
  ConfirmationDialogComponent
} from '@admin/components';
import { pageSizeOptions } from '@admin/constants/paginator-options';
import { createMatDialogConfig } from '@admin/functions/create-mat-dialog-config';
import {
  Author,
  AuthorFilterProps,
  AuthorListItem,
  Filter
} from '@admin/models';
import { AuthorService } from '@admin/services';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { NotificationService } from '@core/services';
import { fadeInOut } from '@shared/animations/fade-in-out';
import { finalize } from 'rxjs/operators';
import { listStagger } from '../../../shared/animations/list-stagger';
import { BaseCrudComponent } from '../base-crud/base-crud.component';
import { Pagination } from './../../models/pagination.model';

@Component({
  templateUrl: './author-crud.component.html',
  styleUrls: ['./author-crud.component.scss'],
  animations: [fadeInOut, listStagger]
})
export class AuthorCrudComponent implements OnInit {
  loadingComplete: boolean = false;
  pageSizeOption: number[] = pageSizeOptions;
  form: FormGroup;
  dataSource: CustomDataSource<AuthorListItem, AuthorFilterProps>;

  public get paginator(): MatPaginator {
    return this.baseCrud.paginator;
  }

  @ViewChild(BaseCrudComponent, { static: true }) baseCrud: BaseCrudComponent;

  authorFilter: Filter<AuthorFilterProps>;
  displayedColumns: string[] = [
    'AuthorID',
    'Name',
    'birthDate',
    'age',
    'Ações'
  ];
  constructor(
    private dialogService: MatDialog,
    private authorService: AuthorService,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      authorID: new FormControl('', [Validators.min(1)]),
      name: new FormControl(''),
      age: new FormControl('')
    });

    this.dataSource = new CustomDataSource<AuthorListItem, AuthorFilterProps>(
      (filter: Filter<AuthorFilterProps>) =>
        this.authorService.getPaginatedAuthors(filter)
    );
  }

  defaultPaginateValues() {
    this.authorFilter.pageNumber = this.paginator.pageIndex + 1;
    this.authorFilter.pageSize = this.paginator.pageSize;
  }

  refreshPaginator() {
    this.authorFilter.pageNumber = this.paginator.pageIndex + 1;
    this.authorFilter.pageSize = this.paginator.pageSize;
    this.dataSource.loadData(this.authorFilter).subscribe((pagination: any) => {
      this.paginator.length = pagination.totalCount;
    });
  }

  openDialog(obj?: { authorID: number }) {
    const dialogRef = this.dialogService.open(
      AuthorDialogComponent,
      createMatDialogConfig({ data: obj })
    );

    dialogRef.afterClosed().subscribe((author: Author) => {
      if (author) {
        this.loadData();
      }
    });
  }

  loadData(): void {
    this.dataSource.loading$
      .pipe(
        finalize(() => {
          this.loadingComplete = true;
        })
      )
      .subscribe((c) => {
        this.loadingComplete = !c;
      });

    this.authorFilter = Object.assign(
      {
        pageNumber: 1,
        pageSize: this.paginator.pageSize,
        sortOrder: 'asc'
      },
      this.form.value
    );

    this.dataSource
      .loadData(this.authorFilter)
      .subscribe((pagination: Pagination) => {
        this.paginator.length = pagination.totalCount;
        this.paginator.firstPage();
      });
  }

  deleteItem(item: Author) {
    const dialogRef = this.dialogService.open(
      ConfirmationDialogComponent,
      createMatDialogConfig({
        data: { id: item.authorID, description: item.name }
      })
    );

    dialogRef.afterClosed().subscribe((confirmed: boolean) => {
      if (confirmed) {
        this.authorService.deleteAuthor(item.authorID).subscribe(() => {
          this.notificationService.showMessage(
            `Você deletou o autor ${item.name} ID:${item.authorID}`
          );
          this.loadData();
        });
      }
    });
  }
}
