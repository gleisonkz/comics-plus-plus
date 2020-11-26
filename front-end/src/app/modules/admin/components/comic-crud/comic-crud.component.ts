import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { pageSizeOptions } from '../../constants/paginator-options';
import { Comic } from '../../../../models/comic.model';
import { CustomDataSource } from '../../classes/custom-data-source';
import { MatPaginator } from '@angular/material/paginator';
import { Filter } from 'src/app/models/filter.model';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { NotificationService } from 'src/app/services/notification.service';
import { GenreDialogComponent } from '../dialogs/genre-dialog/genre-dialog.component';
import { finalize } from 'rxjs/operators';
import { ConfirmationDialogComponent } from '../dialogs/confirmation-dialog/confirmation-dialog.component';
import { ComicService } from '../../../../services/comic.service';

@Component({
  selector: 'cms-comic-crud',
  templateUrl: './comic-crud.component.html',
  styleUrls: ['./comic-crud.component.scss'],
})
export class ComicCrudComponent implements OnInit {
  pageSizeOption: number[] = pageSizeOptions;
  loadingComplete: boolean = false;
  form: FormGroup;
  dataSource: CustomDataSource<Comic>;
  @ViewChild(MatPaginator)
  paginator: MatPaginator;
  comicFilter: Filter;
  displayedColumns: string[] = ['GenreID', 'Nome', 'Ações'];
  constructor(
    private dialogService: MatDialog,
    private comicService: ComicService,
    private changeDetector: ChangeDetectorRef,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      comicID: new FormControl(''),
      description: new FormControl(''),
    });

    this.dataSource = new CustomDataSource<Comic>((filter: Filter) =>
      this.comicService.getComics2(filter)
    );
  }

  defaultPaginateValues() {
    this.comicFilter.pageNumber = this.paginator.pageIndex + 1;
    this.comicFilter.pageSize = this.paginator.pageSize;
  }

  ngAfterViewInit(): void {
    this.paginator.page.subscribe(() => {
      (this.comicFilter.pageNumber = this.paginator.pageIndex + 1),
        (this.comicFilter.pageSize = this.paginator.pageSize),
        this.dataSource
          .loadData(this.comicFilter)
          .subscribe((pagination: any) => {
            this.paginator.length = pagination.totalCount;
          });
    });

    this.paginator._intl.firstPageLabel = 'Primeira Página';
    this.paginator._intl.lastPageLabel = 'Última Página';
    this.paginator._intl.nextPageLabel = 'Próxima Página';
    this.paginator._intl.previousPageLabel = 'Página Anterior';
    this.paginator._intl.itemsPerPageLabel = 'Itens por página';
    this.paginator._intl.getRangeLabel = function (page, pageSize, length) {
      if (length === 0 || pageSize === 0) {
        return '1 de ' + length;
      }
      length = Math.max(length, 0);
      const startIndex = page * pageSize;
      // If the start index exceeds the list length, do not try and fix the end index to the end.
      const endIndex =
        startIndex < length
          ? Math.min(startIndex + pageSize, length)
          : startIndex + pageSize;
      return startIndex + 1 + ' - ' + endIndex + ' de ' + length;
    };

    this.changeDetector.detectChanges();
  }

  openDialog(genre?: Comic) {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.hasBackdrop = true;

    dialogConfig.data = genre;

    const dialogRef = this.dialogService.open(
      GenreDialogComponent,
      dialogConfig
    );

    dialogRef.afterClosed().subscribe((genre: Comic) => {
      if (genre) {
        this.loadData();
      }
    });
  }

  loadData(genre?: Comic): void {
    this.dataSource.loading$
      .pipe(
        finalize(() => {
          this.loadingComplete = true;
        })
      )
      .subscribe((c) => {
        this.loadingComplete = !c;
      });

    this.comicFilter = Object.assign(
      {
        pageNumber: 1,
        pageSize: this.paginator.pageSize,
        sortOrder: 'asc',
      },
      genre
    );

    this.dataSource.loadData(this.comicFilter).subscribe((pagination: any) => {
      this.paginator.length = pagination.totalCount;
      this.paginator.firstPage();
    });
  }

  deleteItem(item: Comic) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = { id: item.id, description: item.title };

    const dialogRef = this.dialogService.open(
      ConfirmationDialogComponent,
      dialogConfig
    );
    dialogRef.afterClosed().subscribe((confirmed: boolean) => {
      if (confirmed) {
        this.comicService.deleteComic(item.id).subscribe((c) => {
          this.notificationService.showMessage(
            `Você deletou o quadrinho ${item.description} ID:${item.id}`
          );
          this.loadData();
        });
      }
    });
  }
}
