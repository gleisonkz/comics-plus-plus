import { CustomDataSource } from '@admin/classes/custom-data-source';
import { ComicInventoryDialogComponent } from '@admin/components';
import { pageSizeOptions } from '@admin/constants/paginator-options';
import { createMatDialogConfig } from '@admin/functions/create-mat-dialog-config';
import { ComicInventory, Filter } from '@admin/models';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { ComicInventoryService } from '@core/services/comic-inventory.service';
import { fadeInOut } from '@shared/animations/fade-in-out';
import { listStagger } from '@shared/animations/list-stagger';
import { finalize } from 'rxjs/operators';
import { BaseCrudComponent } from '../base-crud/base-crud.component';

@Component({
  templateUrl: './inventory-crud.component.html',
  styleUrls: ['./inventory-crud.component.scss'],
  animations: [fadeInOut, listStagger]
})
export class InventoryCrudComponent implements OnInit {
  loadingComplete: boolean = false;
  readonly pageSizeOption: number[] = pageSizeOptions;
  form: FormGroup;

  @ViewChild(BaseCrudComponent, { static: true }) baseCrud: BaseCrudComponent;
  public get paginator(): MatPaginator {
    return this.baseCrud.paginator;
  }

  dataSource: CustomDataSource<ComicInventory>;
  comicInventoryFilter: Filter;
  displayedColumns: string[] = [
    'ComicInventoryID',
    'Name',
    'Quantity',
    'Actions'
  ];
  constructor(
    private dialogService: MatDialog,
    private comicInventoryService: ComicInventoryService
  ) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      comicID: new FormControl(''),
      title: new FormControl('')
    });

    this.dataSource = new CustomDataSource<ComicInventory>((filter: Filter) =>
      this.comicInventoryService.getPaginatedComicsInventory(filter)
    );
  }

  defaultPaginateValues() {
    this.comicInventoryFilter.pageNumber = this.paginator.pageIndex + 1;
    this.comicInventoryFilter.pageSize = this.paginator.pageSize;
  }

  refreshPaginator() {
    this.comicInventoryFilter.pageNumber = this.paginator.pageIndex + 1;
    this.comicInventoryFilter.pageSize = this.paginator.pageSize;
    this.dataSource
      .loadData(this.comicInventoryFilter)
      .subscribe((pagination: any) => {
        this.paginator.length = pagination.totalCount;
      });
  }

  openDialog(comicInventory?: ComicInventory) {
    const dialogRef = this.dialogService.open(
      ComicInventoryDialogComponent,
      createMatDialogConfig({ data: comicInventory })
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
      this.form.value
    );

    this.dataSource
      .loadData(this.comicInventoryFilter)
      .subscribe((pagination: any) => {
        this.paginator.length = pagination.totalCount;
        this.paginator.firstPage();
      });
  }
}
