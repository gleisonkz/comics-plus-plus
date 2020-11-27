import { Author } from './../../../../models/author.model';
import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CustomDataSource } from '../../classes/custom-data-source';
import { MatPaginator } from '@angular/material/paginator';
import { Filter } from 'src/app/models/filter.model';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { AuthorService } from '../../../../services/author.service';
import { NotificationService } from 'src/app/services/notification.service';
import { pageSizeOptions } from '../../constants/paginator-options';
import { finalize } from 'rxjs/operators';
import { ConfirmationDialogComponent } from '../dialogs/confirmation-dialog/confirmation-dialog.component';
import { AuthorDialogComponent } from '../dialogs/author-dialog/author-dialog.component';
import { MatPaginatorService } from '../../../../services/mat-paginator.service';

@Component({
  templateUrl: './author-crud.component.html',
  styleUrls: ['./author-crud.component.scss'],
})
export class AuthorCrudComponent implements OnInit {
  loadingComplete: boolean = false;
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
      name: new FormControl(''),
    });

    this.dataSource = new CustomDataSource<Author>((filter: Filter) =>
      this.authorService.getAuthors(filter)
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
        sortOrder: 'asc',
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