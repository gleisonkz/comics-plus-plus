import { ICustomDataSource } from '@admin/classes/custom-data-source';
import {
  ChangeDetectorRef,
  Component,
  EventEmitter,
  Inject,
  Input,
  OnInit,
  Output,
  ViewChild
} from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatPaginatorService } from '../../services/mat-paginator.service';
import { CUSTOM_DATA_SOURCE } from '../comic-crud/token';

@Component({
  selector: 'cms-base-crud',
  templateUrl: './base-crud.component.html',
  styleUrls: ['./base-crud.component.scss']
})
export class BaseCrudComponent implements OnInit {
  @Input() titleName: string;
  @Input() addButtonText: string;
  @Output() add = new EventEmitter<void>();
  @Output() load = new EventEmitter<void>();
  @ViewChild(MatPaginator) paginator: MatPaginator;
  readonly pageSizeOption = [5, 10, 20];

  constructor(
    private matPaginatorService: MatPaginatorService,
    private changeDetector: ChangeDetectorRef,
    @Inject(CUSTOM_DATA_SOURCE)
    public dataSource: ICustomDataSource
  ) {}

  ngOnInit(): void {}

  ngAfterViewInit(): void {
    this.matPaginatorService.applyGlobalization(this.paginator);
    this.changeDetector.detectChanges();
  }

  openDialog() {
    this.add.emit();
  }
  loadData() {
    this.load.emit();
  }
}
