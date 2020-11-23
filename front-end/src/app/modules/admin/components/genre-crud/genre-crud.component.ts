import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { GenreDialogComponent } from '../dialogs/genre-dialog/genre-dialog.component';

@Component({
  templateUrl: './genre-crud.component.html',
  styleUrls: ['./genre-crud.component.scss'],
})
export class GenreCrudComponent implements OnInit {
  constructor(private dialogService: MatDialog) {}

  ngOnInit(): void {}

  openDialog() {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.hasBackdrop = false;

    this.dialogService.open(GenreDialogComponent, dialogConfig);
  }
}
