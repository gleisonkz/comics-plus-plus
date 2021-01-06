import {
  ChangeDetectorRef,
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  ViewChild
} from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatPaginatorService } from '../../services/mat-paginator.service';

@Component({
  selector: 'cms-base-crud',
  templateUrl: './base-crud.component.html',
  styleUrls: ['./base-crud.component.scss']
})
export class BaseCrudComponent implements OnInit {
  @Input() titleName: string;
  @Input() loadingComplete = false;
  @Input() addButtonText: string;
  @Output() add = new EventEmitter();
  @Output() load = new EventEmitter();
  @Output() paginatorEvent = new EventEmitter();
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private matPaginatorService: MatPaginatorService,
    private changeDetector: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    console.log('2');
  }

  ngAfterViewInit(): void {
    this.paginator.page.subscribe(() => {
      console.log('paginatorEvent');

      this.paginatorEvent.emit();
    });

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
