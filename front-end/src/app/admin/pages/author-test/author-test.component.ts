import { CustomDataSource } from '@admin/classes/custom-data-source';
import {
  AuthorDialogComponent,
  ConfirmationDialogComponent
} from '@admin/components';
import { pageSizeOptions } from '@admin/constants/paginator-options';
import { Author, Filter } from '@admin/models';
import { AuthorService, MatPaginatorService } from '@admin/services';
import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { NotificationService } from '@core/services';
import { listStagger } from '@shared/animations/list-stagger';
import { finalize } from 'rxjs/operators';
import { BaseCrudComponent } from '../base-crud/base-crud.component';

@Component({
  templateUrl: './author-test.component.html',
  styleUrls: ['./author-test.component.scss'],
  selector: 'author-test',
  animations: [listStagger]
})
export class AuthorTestComponent implements OnInit {
  loadingComplete: boolean = false;
  pageSizeOption: number[] = pageSizeOptions;
  title = 'Autores';
  form: FormGroup;
  dataSource: CustomDataSource<Author>;

  public get paginator(): MatPaginator {
    return this.baseCrud.paginator;
  }

  @ViewChild(BaseCrudComponent, { static: true }) baseCrud: BaseCrudComponent;

  authorFilter: Filter;
  displayedColumns: string[] = ['AuthorID', 'Name', 'Ações'];
  constructor(
    private dialogService: MatDialog,
    private authorService: AuthorService,
    private changeDetector: ChangeDetectorRef,
    private notificationService: NotificationService,
    private matPaginatorService: MatPaginatorService
  ) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      authorID: new FormControl('', [Validators.min(1)]),
      name: new FormControl('')
    });

    this.dataSource = new CustomDataSource<Author>((filter: Filter) =>
      this.authorService.getPaginatedAuthors(filter)
    );
  }

  defaultPaginateValues() {
    this.authorFilter.pageNumber = this.paginator.pageIndex + 1;
    this.authorFilter.pageSize = this.paginator.pageSize;
  }

  ngAfterViewInit(): void {
    // this.paginator.page.subscribe(() => {
    //   (this.authorFilter.pageNumber = this.paginator.pageIndex + 1),
    //     (this.authorFilter.pageSize = this.paginator.pageSize),
    //     this.dataSource
    //       .loadData(this.authorFilter)
    //       .subscribe((pagination: any) => {
    //         this.paginator.length = pagination.totalCount;
    //       });
    // });
    // this.matPaginatorService.applyGlobalization(this.paginator);
    // console.log('base', this.baseCrud);
    // this.changeDetector.detectChanges();
  }

  refreshPaginator() {
    this.authorFilter.pageNumber = this.paginator.pageIndex + 1;
    this.authorFilter.pageSize = this.paginator.pageSize;
    this.dataSource.loadData(this.authorFilter).subscribe((pagination: any) => {
      this.paginator.length = pagination.totalCount;
    });
  }

  openDialog(author?: Author) {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.hasBackdrop = true;

    dialogConfig.data = author;

    const dialogRef = this.dialogService.open(
      AuthorDialogComponent,
      dialogConfig
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

    this.dataSource.loadData(this.authorFilter).subscribe((pagination: any) => {
      this.paginator.length = pagination.totalCount;
      this.paginator.firstPage();
    });
  }

  deleteItem(item: Author) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = { id: item.authorID, description: item.name };

    const dialogRef = this.dialogService.open(
      ConfirmationDialogComponent,
      dialogConfig
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
