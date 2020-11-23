import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { GenreDialogComponent } from '../dialogs/genre-dialog/genre-dialog.component';

export interface Genre {
  genreID: number;
  name: string;
}

@Component({
  templateUrl: './genre-crud.component.html',
  styleUrls: ['./genre-crud.component.scss'],
})
export class GenreCrudComponent implements OnInit {
  form: FormGroup;
  genres: Genre[];
  dataSource: MatTableDataSource<Genre>;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  displayedColumns: string[] = ['GenreID', 'Nome', 'Ações'];
  constructor(private dialogService: MatDialog) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      genreID: new FormControl(''),
      name: new FormControl(''),
    });
    this.genres = [
      { genreID: 1, name: 'Drama' },
      // { genreID: 2, name: 'Action' },
      // { genreID: 3, name: 'Romance' },
      // { genreID: 4, name: 'Terror' },
      // { genreID: 1, name: 'Drama' },
      // { genreID: 2, name: 'Action' },
      // { genreID: 3, name: 'Romance' },
      // { genreID: 4, name: 'Terror' },
      // { genreID: 1, name: 'Drama' },
      // { genreID: 2, name: 'Action' },
      // { genreID: 3, name: 'Romance' },
      // { genreID: 4, name: 'Terror' },
      // { genreID: 1, name: 'Drama' },
      // { genreID: 2, name: 'Action' },
      // { genreID: 3, name: 'Romance' },
      // { genreID: 4, name: 'Terror' },
    ];
    this.dataSource = new MatTableDataSource<Genre>(this.genres);
    setTimeout(() => {
      this.paginator._intl.firstPageLabel = 'Primeira Página';
      this.paginator._intl.lastPageLabel = 'Última Página';
      this.paginator._intl.nextPageLabel = 'Próxima Página';
      this.paginator._intl.previousPageLabel = 'Página Anterior';
      this.paginator._intl.itemsPerPageLabel = 'Itens por página';
      this.paginator._intl.getRangeLabel = function (page, pageSize, length) {
        if (length === 0 || pageSize === 0) {
          return '0 od ' + length;
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

      this.dataSource.paginator = this.paginator;
    }, 0);
  }

  openDialog() {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.hasBackdrop = true;

    dialogConfig.data = {
      id: 1,
      name: 'Drama',
    };

    this.dialogService.open(GenreDialogComponent, dialogConfig);
  }

  deleteGenre(item: Genre) {
    console.log(item);
  }
  editGenre(item: Genre) {
    console.log(item);
  }
}