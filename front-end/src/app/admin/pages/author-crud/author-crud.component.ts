import { CustomDataSource } from '@admin/classes/custom-data-source';
import {
  AuthorDialogComponent,
  ConfirmationDialogComponent
} from '@admin/components';
import { pageSizeOptions } from '@admin/constants/paginator-options';
import { Author, Filter } from '@admin/models';
import { AuthorService } from '@admin/services';
import { MatPaginatorService } from '@admin/services/mat-paginator.service';
import {
  ChangeDetectorRef,
  Component,
  HostBinding,
  OnInit,
  ViewChild
} from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { NotificationService } from '@core/services';
import { fadeInOut } from '@shared/animations/fade-in-out';
import { finalize } from 'rxjs/operators';
import { listStagger } from '../../../shared/animations/list-stagger';

@Component({
  templateUrl: './author-crud.component.html',
  styleUrls: ['./author-crud.component.scss'],
  animations: [fadeInOut, listStagger]
})
export class AuthorCrudComponent implements OnInit {
  loadingComplete: boolean = false;
  @HostBinding('@fadeInOut')
  pageSizeOption: number[] = pageSizeOptions;
  form: FormGroup;
  dataSource: CustomDataSource<Author>;
  @ViewChild(MatPaginator)
  paginator: MatPaginator;
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
    this.paginator.page.subscribe(() => {
      (this.authorFilter.pageNumber = this.paginator.pageIndex + 1),
        (this.authorFilter.pageSize = this.paginator.pageSize),
        this.dataSource
          .loadData(this.authorFilter)
          .subscribe((pagination: any) => {
            this.paginator.length = pagination.totalCount;
          });
    });

    this.matPaginatorService.applyGlobalization(this.paginator);
    this.changeDetector.detectChanges();
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

  loadData(author?: Author): void {
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
      author
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
