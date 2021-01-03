import { CustomDataSource } from '@admin/classes/custom-data-source';
import { ComicInventoryDialogComponent } from '@admin/components';
import { pageSizeOptions } from '@admin/constants/paginator-options';
import { ComicInventory, Filter } from '@admin/models';
import { MatPaginatorService } from '@admin/services/mat-paginator.service';
import {
  ChangeDetectorRef,
  Component,
  HostBinding,
  OnInit,
  ViewChild
} from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { ComicService, NotificationService } from '@core/services';
import { fadeInOut } from '@shared/animations/fade-in-out';
import { listStagger } from '@shared/animations/list-stagger';
import { finalize } from 'rxjs/operators';

@Component({
  templateUrl: './inventory-crud.component.html',
  styleUrls: ['./inventory-crud.component.scss'],
  animations: [fadeInOut, listStagger]
})
export class InventoryCrudComponent implements OnInit {
  loadingComplete: boolean = false;
  readonly pageSizeOption: number[] = pageSizeOptions;
  form: FormGroup;
  @HostBinding('@fadeInOut')
  dataSource: CustomDataSource<ComicInventory>;
  @ViewChild(MatPaginator)
  paginator: MatPaginator;
  comicInventoryFilter: Filter;
  displayedColumns: string[] = [
    'ComicInventoryID',
    'Name',
    'Quantity',
    'Actions'
  ];
  constructor(
    private dialogService: MatDialog,
    private comicService: ComicService,
    private changeDetector: ChangeDetectorRef,
    private notificationService: NotificationService,
    private matPaginatorService: MatPaginatorService
  ) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      comicID: new FormControl(''),
      title: new FormControl('')
    });

    this.dataSource = new CustomDataSource<ComicInventory>((filter: Filter) =>
      this.comicService.getPaginatedComicsInventory(filter)
    );
  }

  defaultPaginateValues() {
    this.comicInventoryFilter.pageNumber = this.paginator.pageIndex + 1;
    this.comicInventoryFilter.pageSize = this.paginator.pageSize;
  }

  ngAfterViewInit(): void {
    this.paginator.page.subscribe(() => {
      (this.comicInventoryFilter.pageNumber = this.paginator.pageIndex + 1),
        (this.comicInventoryFilter.pageSize = this.paginator.pageSize),
        this.dataSource
          .loadData(this.comicInventoryFilter)
          .subscribe((pagination: any) => {
            this.paginator.length = pagination.totalCount;
          });
    });

    this.matPaginatorService.applyGlobalization(this.paginator);
    this.changeDetector.detectChanges();
  }

  openDialog(comicInventory: ComicInventory) {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.hasBackdrop = true;

    dialogConfig.data = comicInventory;

    const dialogRef = this.dialogService.open(
      ComicInventoryDialogComponent,
      dialogConfig
    );

    dialogRef.afterClosed().subscribe((comicInventory: ComicInventory) => {
      if (comicInventory) {
        this.loadData();
      }
    });
  }

  loadData(comicInventory?: ComicInventory): void {
    this.dataSource.loading$
      .pipe(
        finalize(() => {
          this.loadingComplete = true;
        })
      )
      .subscribe((c) => {
        this.loadingComplete = !c;
      });

    this.comicInventoryFilter = Object.assign(
      {
        pageNumber: 1,
        pageSize: this.paginator.pageSize,
        sortOrder: 'asc'
      },
      comicInventory
    );

    this.dataSource
      .loadData(this.comicInventoryFilter)
      .subscribe((pagination: any) => {
        this.paginator.length = pagination.totalCount;
        this.paginator.firstPage();
      });
  }
}
