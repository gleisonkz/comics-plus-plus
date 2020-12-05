import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { finalize } from 'rxjs/operators';
import { Filter } from 'src/app/modules/admin/models/filter.model';
import { NotificationService } from 'src/app/modules/shared/services/notification.service';
import { Comic } from '../../../../models/comic.model';
import { AuthorService } from '../../../../services/author.service';
import { ComicService } from '../../../../services/comic.service';
import { GenreService } from '../../../../services/genre.service';
import { CustomDataSource } from '../../classes/custom-data-source';
import { ComicDialogComponent } from '../../components/comic-dialog/comic-dialog.component';
import { ConfirmationDialogComponent } from '../../components/confirmation-dialog/confirmation-dialog.component';
import { pageSizeOptions } from '../../constants/paginator-options';
import { ComicList } from '../../models/comic-list.model';
import { MatPaginatorService } from '../../services/mat-paginator.service';

@Component({
  selector: 'cms-comic-crud',
  templateUrl: './comic-crud.component.html',
  styleUrls: ['./comic-crud.component.scss'],
})
export class ComicCrudComponent implements OnInit {
  pageSizeOption: number[] = pageSizeOptions;
  loadingComplete: boolean = false;
  form: FormGroup;
  dataSource: CustomDataSource<ComicList>;
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
    'Ações',
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
      genres: new FormControl([]),
    });

    this.dataSource = new CustomDataSource<ComicList>((filter: Filter) =>
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
    const dialogConfig = new MatDialogConfig<Comic>();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.hasBackdrop = true;
    dialogConfig.data = comic;

    const dialogRef = this.dialogService.open(
      ComicDialogComponent,
      dialogConfig
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
        sortOrder: 'asc',
      },
      comic
    );

    this.dataSource.loadData(this.comicFilter).subscribe((pagination: any) => {
      this.paginator.length = pagination.totalCount;
      this.paginator.firstPage();
    });
  }

  deleteItem(item: Comic) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = { id: item.comicID, description: item.title };

    const dialogRef = this.dialogService.open(
      ConfirmationDialogComponent,
      dialogConfig
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