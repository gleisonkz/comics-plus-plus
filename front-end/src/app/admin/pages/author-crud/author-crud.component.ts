import { CustomDataSource } from '@admin/classes/custom-data-source';
import { AuthorDialogComponent, ConfirmationDialogComponent } from '@admin/components';
import { createMatDialogConfig } from '@admin/functions/create-mat-dialog-config';
import { Author, AuthorFilterProps, AuthorListItem, Filter } from '@admin/models';
import { Pagination } from '@admin/models/pagination.model';
import { BaseCrudComponent } from '@admin/pages/base-crud/base-crud.component';
import { customDataSourceFactory } from '@admin/pages/comic-crud/comic-crud.component';
import { CUSTOM_DATA_SOURCE } from '@admin/pages/comic-crud/token';
import { AuthorService } from '@admin/services';
import { ChangeDetectorRef, Component, Inject, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { NotificationService } from '@core/services';
import { fadeInOut } from '@shared/animations/fade-in-out';
import { listStagger } from '@shared/animations/list-stagger';
import { finalize } from 'rxjs/operators';

export const authorDataSourceFactory = (service: AuthorService) =>
  customDataSourceFactory<AuthorListItem, AuthorFilterProps, AuthorService>(service);

@Component({
  templateUrl: './author-crud.component.html',
  styleUrls: ['./author-crud.component.scss'],
  animations: [fadeInOut, listStagger],
  providers: [
    {
      provide: CUSTOM_DATA_SOURCE,
      useFactory: authorDataSourceFactory,
      deps: [AuthorService]
    }
  ]
})
export class AuthorCrudComponent implements OnInit {
  loadingComplete: boolean = false;
  form: FormGroup;

  authorFilter: Filter<AuthorFilterProps>;
  displayedColumns: string[] = ['AuthorID', 'Name', 'birthDate', 'age', 'Ações'];

  @ViewChild(BaseCrudComponent, { static: true }) baseCrud: BaseCrudComponent;

  public get paginator(): MatPaginator {
    return this.baseCrud.paginator;
  }

  constructor(
    private dialogService: MatDialog,
    private authorService: AuthorService,
    private notificationService: NotificationService,
    private changeDetectorRef: ChangeDetectorRef,
    @Inject(CUSTOM_DATA_SOURCE)
    public dataSource: CustomDataSource<AuthorListItem, AuthorFilterProps>
  ) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      authorID: new FormControl('', [Validators.min(1)]),
      name: new FormControl(''),
      age: new FormControl('')
    });

    // this.dataSource = new CustomDataSource<AuthorListItem, AuthorFilterProps>(
    //   (filter: Filter<AuthorFilterProps>) =>
    //     this.authorService.getPaginatedAuthors(filter)
    // );
  }

  ngAfterViewInit(): void {
    this.paginator.page.subscribe(() => {
      this.authorFilter.pageNumber = this.paginator.pageIndex + 1;
      this.authorFilter.pageSize = this.paginator.pageSize;
      this.dataSource.loadData(this.authorFilter).subscribe((pagination: Pagination) => {
        this.paginator.length = pagination.totalCount;
      });
    });
    this.changeDetectorRef.detectChanges();
  }

  openDialog(obj?: { authorID: number }) {
    const dialogRef = this.dialogService.open(AuthorDialogComponent, createMatDialogConfig({ data: obj }));

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

    this.dataSource.loadData(this.authorFilter).subscribe((pagination: Pagination) => {
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
          this.notificationService.showMessage(`Você deletou o autor ${item.name} ID:${item.authorID}`);
          this.loadData();
        });
      }
    });
  }
}
