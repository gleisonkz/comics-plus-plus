import { CustomDataSource } from '@admin/classes/custom-data-source';
import { ComicDialogComponent } from '@admin/components';
import { pageSizeOptions } from '@admin/constants/paginator-options';
import { createMatDialogConfig } from '@admin/functions/create-mat-dialog-config';
import { Comic, ComicListItem, Filter } from '@admin/models';
import { AuthorService, GenreService } from '@admin/services';
import { MatPaginatorService } from '@admin/services/mat-paginator.service';
import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { ComicService, NotificationService } from '@core/services';
import { listStagger } from '@shared/animations/list-stagger';
import { finalize } from 'rxjs/operators';
import { fadeInOut } from '../../../shared/animations/fade-in-out';

@Component({
  selector: 'cms-comic-crud',
  templateUrl: './comic-crud.component.html',
  styleUrls: ['./comic-crud.component.scss'],
  animations: [fadeInOut, listStagger]
})
export class ComicCrudComponent implements OnInit {
  pageSizeOption: number[] = pageSizeOptions;
  loadingComplete: boolean = false;
  form: FormGroup;

  dataSource: CustomDataSource<ComicListItem>;
  @ViewChild(MatPaginator)
  paginator: MatPaginator;
  comicFilter: Filter;
  displayedColumns: string[] = [
    'ComicID',
    'Titulo',
    'Descrição',
    'Preço',
    'Ano',
    'Páginas',
    'Ações'
  ];
  constructor(
    private dialogService: MatDialog,
    private comicService: ComicService,
    private changeDetector: ChangeDetectorRef,
    private notificationService: NotificationService,
    private matPaginatorService: MatPaginatorService,
    private authorService: AuthorService,
    private genreService: GenreService
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

    this.dataSource = new CustomDataSource<ComicListItem>((filter: Filter) =>
      this.comicService.getPaginatedComics(filter)
    );
  }

  getAuthorByNameCallback(searchTerm: string) {
    return this.authorService.getAuthorsByName(searchTerm);
  }

  getGenresByNameCallback(searchTerm: string) {
    return this.genreService.getGenresByName(searchTerm);
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

    this.matPaginatorService.applyGlobalization(this.paginator);
    this.changeDetector.detectChanges();
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

  loadData(comic?: Comic): void {
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
        sortOrder: 'asc'
      },
      comic
    );

    this.dataSource.loadData(this.comicFilter).subscribe((pagination: any) => {
      this.paginator.length = pagination.totalCount;
      this.paginator.firstPage();
    });
  }

  deleteItem(item: Comic) {
    const dialogRef = this.dialogService.open(
      ComicDialogComponent,
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
