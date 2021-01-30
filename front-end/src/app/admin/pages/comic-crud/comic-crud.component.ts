import { CustomDataSource } from '@admin/classes/custom-data-source';
import { ComicDialogComponent } from '@admin/components';
import { createMatDialogConfig } from '@admin/functions/create-mat-dialog-config';
import { Comic, ComicFilterProps, ComicListItem, Filter } from '@admin/models';
import { AuthorService, GenreService } from '@admin/services';
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { ComicService, NotificationService } from '@core/services';
import { listStagger } from '@shared/animations/list-stagger';
import { delay } from 'rxjs/operators';
import { fadeInOut } from '../../../shared/animations/fade-in-out';
import { BaseCrudComponent } from '../base-crud/base-crud.component';
import { ConfirmationDialogComponent } from './../../components/confirmation-dialog/confirmation-dialog.component';
import { Pagination } from './../../models/pagination.model';
import { CUSTOM_DATA_SOURCE } from './toke';

export interface PaginatedService<TFilterProps> {
  getPaginatedEntities(filter: Filter<TFilterProps>): any;
}

export const customDataSourceFactory = <
  TListItem,
  TFilterProps,
  TService extends PaginatedService<TFilterProps>
>(
  service: TService
) => {
  return new CustomDataSource<TListItem, TFilterProps>(
    (filter: Filter<TFilterProps>) =>
      service.getPaginatedEntities(filter).pipe(delay(200))
  );
};

export const comicDataSourceFactory = (service: ComicService) =>
  customDataSourceFactory<ComicListItem, ComicFilterProps, ComicService>(
    service
  );

@Component({
  selector: 'cms-comic-crud',
  templateUrl: './comic-crud.component.html',
  styleUrls: ['./comic-crud.component.scss'],
  animations: [fadeInOut, listStagger],
  providers: [
    {
      provide: CUSTOM_DATA_SOURCE,
      useFactory: comicDataSourceFactory,
      deps: [ComicService]
    }
  ]
})
export class ComicCrudComponent implements OnInit {
  loadingComplete: boolean = false;
  form: FormGroup;

  comicFilter: Filter<ComicFilterProps>;
  displayedColumns: string[] = [
    'ComicID',
    'Titulo',
    'Descrição',
    'Preço',
    'Ano',
    'Páginas',
    'Ações'
  ];

  @ViewChild(BaseCrudComponent, { static: true }) baseCrud: BaseCrudComponent;

  public get paginator(): MatPaginator {
    return this.baseCrud.paginator;
  }

  constructor(
    private dialogService: MatDialog,
    private comicService: ComicService,
    private notificationService: NotificationService,
    private authorService: AuthorService,
    private genreService: GenreService,
    @Inject(CUSTOM_DATA_SOURCE)
    public dataSource: CustomDataSource<ComicListItem, ComicFilterProps>
  ) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      comicID: new FormControl(''),
      title: new FormControl(''),
      description: new FormControl(''),
      price: new FormControl(''),
      year: new FormControl(''),
      pages: new FormControl(''),
      authors: new FormControl([]),
      genres: new FormControl([])
    });

    // this.dataSource = new CustomDataSource<ComicListItem, ComicFilterProps>(
    //   (filter: Filter<ComicFilterProps>) =>
    //     this.comicService.getPaginatedComics(filter)
    // );
  }

  ngAfterViewInit(): void {
    this.paginator.page.subscribe(() => {
      this.comicFilter.pageNumber = this.paginator.pageIndex + 1;
      this.comicFilter.pageSize = this.paginator.pageSize;
      this.dataSource
        .loadData(this.comicFilter)
        .subscribe((pagination: Pagination) => {
          this.paginator.length = pagination.totalCount;
        });
    });
  }

  getAuthorByNameCallback(searchTerm: string) {
    return this.authorService.getAuthorsByName(searchTerm);
  }

  getGenresByNameCallback(searchTerm: string) {
    return this.genreService.getGenresByName(searchTerm);
  }

  openDialog(comic?: Comic) {
    const dialogRef = this.dialogService.open(
      ComicDialogComponent,
      createMatDialogConfig({
        data: comic
      })
    );

    dialogRef.afterClosed().subscribe((isUpdated: boolean) => {
      if (isUpdated) {
        this.loadData();
      }
    });
  }

  loadData(): void {
    this.comicFilter = Object.assign(
      {
        pageNumber: 1,
        pageSize: this.paginator.pageSize,
        sortOrder: 'asc'
      },
      this.form.value
    );

    this.dataSource
      .loadData(this.comicFilter)
      .subscribe((pagination: Pagination) => {
        this.paginator.length = pagination.totalCount;
        this.paginator.firstPage();
      });
  }

  deleteItem(item: Comic) {
    const dialogRef = this.dialogService.open(
      ConfirmationDialogComponent,
      createMatDialogConfig({
        data: { id: item.comicID, description: item.title }
      })
    );

    dialogRef.afterClosed().subscribe((confirmed: boolean) => {
      if (confirmed) {
        this.comicService.deleteComic(item.comicID).subscribe(() => {
          this.notificationService.showMessage(
            `Você deletou o quadrinho ${item.title} ID:${item.comicID}`
          );
          this.loadData();
        });
      }
    });
  }
}
