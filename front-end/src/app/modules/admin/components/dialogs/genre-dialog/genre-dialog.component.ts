import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  templateUrl: './genre-dialog.component.html',
  styleUrls: ['./genre-dialog.component.scss'],
})
export class GenreDialogComponent implements OnInit {
  form: FormGroup;
  description: string;

  constructor(private dialogRef: MatDialogRef<GenreDialogComponent>) {}

  ngOnInit(): void {}

  save() {
    this.dialogRef.close(this.form.value);
  }

  close() {
    this.dialogRef.close();
  }
}
