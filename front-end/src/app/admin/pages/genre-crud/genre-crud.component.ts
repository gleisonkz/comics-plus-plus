import { CustomDataSource } from '@admin/classes/custom-data-source';
import {
  ConfirmationDialogComponent,
  GenreDialogComponent
} from '@admin/components';
import { pageSizeOptions } from '@admin/constants/paginator-options';
import { createMatDialogConfig } from '@admin/functions/create-mat-dialog-config';
import { Filter, Genre } from '@admin/models';
import { GenreListItem } from '@admin/models/genre-list.model';
import { GenreService } from '@admin/services';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { NotificationService } from '@core/services';
import { fadeInOut } from '@shared/animations/fade-in-out';
import { listStagger } from '@shared/animations/list-stagger';
import { finalize } from 'rxjs/operators';
import { BaseCrudComponent } from '../base-crud/base-crud.component';

@Component({
  templateUrl: './genre-crud.component.html',
  styleUrls: ['./genre-crud.component.scss'],
  animations: [fadeInOut, listStagger]
})
export class GenreCrudComponent implements OnInit {
  loadingComplete: boolean = false;
  readonly pageSizeOption: number[] = pageSizeOptions;
  form: FormGroup;

  @ViewChild(BaseCrudComponent, { static: true }) baseCrud: BaseCrudComponent;
  public get paginator(): MatPaginator {
    return this.baseCrud.paginator;
  }

  dataSource: CustomDataSource<GenreListItem>;
  genreFilter: Filter;
  displayedColumns: string[] = ['GenreID', 'Nome', 'Ações'];
  constructor(
    private dialogService: MatDialog,
    private genreService: GenreService,
    private notificationService: NotificationService
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

  refreshPaginator() {
    this.genreFilter.pageNumber = this.paginator.pageIndex + 1;
    this.genreFilter.pageSize = this.paginator.pageSize;
    this.dataSource.loadData(this.genreFilter).subscribe((pagination: any) => {
      this.paginator.length = pagination.totalCount;
    });
  }

  openDialog(genre?: Genre) {
    const dialogRef = this.dialogService.open(
      GenreDialogComponent,
      createMatDialogConfig({ data: genre })
    );
    dialogRef.afterClosed().subscribe((isCreatedOrUpdated: boolean) => {
      if (isCreatedOrUpdated) {
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
      this.form.value
    );

    this.dataSource.loadData(this.genreFilter).subscribe((pagination: any) => {
      this.paginator.length = pagination.totalCount;
      this.paginator.firstPage();
    });
  }

  deleteItem(item: Genre) {
    const dialogRef = this.dialogService.open(
      ConfirmationDialogComponent,
      createMatDialogConfig({
        data: { id: item.genreID, description: item.description }
      })
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
    const dialogRef = this.dialogService.open(
      ConfirmationDialogComponent,
      createMatDialogConfig({
        data: {
          id: item.genreID,
          description: item.description,
          message:
            'Você tem certeza que deseja remover os vínculos do registro abaixo?'
        }
      })
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
