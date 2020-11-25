import { Genre } from './../../../../models/genre.model';
import {
  AfterViewInit,
  ChangeDetectorRef,
  Component,
  OnInit,
  ViewChild,
} from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { GenreDialogComponent } from '../dialogs/genre-dialog/genre-dialog.component';
import { GenreService } from '../../../../services/genre.service';
import { GenresDataSource } from './genres-data-source';
import { finalize } from 'rxjs/operators';
import { NotificationService } from '../../../../services/notification.service';
import { ConfirmationDialogComponent } from '../dialogs/confirmation-dialog/confirmation-dialog.component';

@Component({
  templateUrl: './genre-crud.component.html',
  styleUrls: ['./genre-crud.component.scss'],
})
export class GenreCrudComponent implements OnInit, AfterViewInit {
  loadingComplete: boolean = false;
  form: FormGroup;
  dataSource: GenresDataSource;
  @ViewChild(MatPaginator)
  paginator: MatPaginator;
  displayedColumns: string[] = ['GenreID', 'Nome', 'Ações'];
  constructor(
    private dialogService: MatDialog,
    private genreService: GenreService,
    private changeDetector: ChangeDetectorRef,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      genreID: new FormControl(''),
      name: new FormControl(''),
    });

    this.dataSource = new GenresDataSource(this.genreService);
  }

  ngAfterViewInit(): void {
    this.paginator.page.subscribe(() => {
      this.dataSource
        .loadGenres(
          '',
          'asc',
          this.paginator.pageIndex + 1,
          this.paginator.pageSize
        )
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

  openDialog(genre?: Genre) {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.hasBackdrop = true;

    dialogConfig.data = genre;

    const dialogRef = this.dialogService.open(
      GenreDialogComponent,
      dialogConfig
    );

    dialogRef.afterClosed().subscribe((genre: Genre) => {
      if (genre) {
        this.loadGenres();
      }
    });
  }

  loadGenres(): void {
    this.dataSource.loading$
      .pipe(
        finalize(() => {
          this.loadingComplete = true;
        })
      )
      .subscribe((c) => {
        this.loadingComplete = !c;
      });

    this.dataSource
      .loadGenres(
        '',
        'asc',
        this.paginator.pageIndex + 1,
        this.paginator.pageSize
      )
      .subscribe((pagination: any) => {
        this.paginator.length = pagination.totalCount;
      });
  }

  deleteGenre(item: Genre) {
    const dialogRef = this.dialogService.open(ConfirmationDialogComponent);
    dialogRef.afterClosed().subscribe((confirmed: boolean) => {
      if (confirmed) {
        this.genreService.deleteGenre(item.genreID).subscribe((c) => {
          this.notificationService.showMessage(
            `Você deletou a categoria ${item.description} ID:${item.genreID}`
          );
          this.loadGenres();
        });
      }
    });
  }
}
