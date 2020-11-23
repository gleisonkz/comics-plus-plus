import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { GenreDialogComponent } from '../dialogs/genre-dialog/genre-dialog.component';

export interface Genre {
  genreID: number;
  Name: string;
}

@Component({
  templateUrl: './genre-crud.component.html',
  styleUrls: ['./genre-crud.component.scss'],
})
export class GenreCrudComponent implements OnInit {
  form: FormGroup;
  genres: Genre[];
  constructor(private dialogService: MatDialog) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      genreID: new FormControl(''),
      name: new FormControl(''),
    });
    this.genres = [{ genreID: 1, Name: 'Drama' }];
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
}
