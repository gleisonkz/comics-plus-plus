import { CustomDataSource } from '@admin/classes/custom-data-source';
import {
  ConfirmationDialogComponent,
  GenreDialogComponent
} from '@admin/components';
import { pageSizeOptions } from '@admin/constants/paginator-options';
import { Filter, Genre } from '@admin/models';
import { GenreService } from '@admin/services';
import { MatPaginatorService } from '@admin/services/mat-paginator.service';
import {
  AfterViewInit,
  ChangeDetectorRef,
  Component,
  HostBinding,
  OnInit,
  ViewChild
} from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { NotificationService } from '@core/services';
import { fadeInOut } from '@shared/animations/fade-in-out';
import { listStagger } from '@shared/animations/list-stagger';
import { finalize } from 'rxjs/operators';

@Component({
  templateUrl: './genre-crud.component.html',
  styleUrls: ['./genre-crud.component.scss'],
  animations: [fadeInOut, listStagger]
})
export class GenreCrudComponent implements OnInit, AfterViewInit {
  loadingComplete: boolean = false;
  readonly pageSizeOption: number[] = pageSizeOptions;
  form: FormGroup;
  @HostBinding('@fadeInOut')
  dataSource: CustomDataSource<Genre>;
  @ViewChild(MatPaginator)
  paginator: MatPaginator;
  genreFilter: Filter;
  displayedColumns: string[] = ['GenreID', 'Nome', 'Ações'];
  constructor(
    private dialogService: MatDialog,
    private genreService: GenreService,
    private changeDetector: ChangeDetectorRef,
    private notificationService: NotificationService,
    private matPaginatorService: MatPaginatorService
  ) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      genreID: new FormControl(''),
      description: new FormControl('')
    });

    this.dataSource = new CustomDataSource<Genre>((filter: Filter) =>
      this.genreService.getPaginatedGenres(filter)
    );
  }

  defaultPaginateValues() {
    this.genreFilter.pageNumber = this.paginator.pageIndex + 1;
    this.genreFilter.pageSize = this.paginator.pageSize;
  }

  ngAfterViewInit(): void {
    this.paginator.page.subscribe(() => {
      (this.genreFilter.pageNumber = this.paginator.pageIndex + 1),
        (this.genreFilter.pageSize = this.paginator.pageSize),
        this.dataSource
          .loadData(this.genreFilter)
          .subscribe((pagination: any) => {
            this.paginator.length = pagination.totalCount;
          });
    });

    this.matPaginatorService.applyGlobalization(this.paginator);
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
        this.loadData();
      }
    });
  }

  loadData(genre?: Genre): void {
    this.dataSource.loading$
      .pipe(
        finalize(() => {
          this.loadingComplete = true;
        })
      )
      .subscribe((c) => {
        this.loadingComplete = !c;
      });

    this.genreFilter = Object.assign(
      {
        pageNumber: 1,
        pageSize: this.paginator.pageSize,
        sortOrder: 'asc'
      },
      genre
    );

    this.dataSource.loadData(this.genreFilter).subscribe((pagination: any) => {
      this.paginator.length = pagination.totalCount;
      this.paginator.firstPage();
    });
  }

  deleteItem(item: Genre) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = { id: item.genreID, description: item.description };

    const dialogRef = this.dialogService.open(
      ConfirmationDialogComponent,
      dialogConfig
    );
    dialogRef.afterClosed().subscribe((confirmed: boolean) => {
      if (confirmed) {
        this.genreService.deleteGenre(item.genreID).subscribe((c) => {
          this.notificationService.showMessage(
            `Você deletou a categoria ${item.description} ID:${item.genreID}`
          );
          this.loadData();
        });
      }
    });
  }

  deleteGenreRelationships(item: Genre) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = {
      id: item.genreID,
      description: item.description,
      message:
        'Você tem certeza que deseja remover os vínculos do registro abaixo?'
    };

    const dialogRef = this.dialogService.open(
      ConfirmationDialogComponent,
      dialogConfig
    );
    dialogRef.afterClosed().subscribe((confirmed: boolean) => {
      if (confirmed) {
        this.genreService
          .deleteGenreRelationships(item.genreID)
          .subscribe(() => {
            this.notificationService.showMessage(
              `Você removeu os vínculos da categoria ${item.description} ID:${item.genreID}`
            );
          });
      }
    });
  }
}
