import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  templateUrl: './genre-dialog.component.html',
  styleUrls: ['./genre-dialog.component.scss'],
})
export class GenreDialogComponent implements OnInit {
  form: FormGroup;
  id: number;

  constructor(
    private dialogRef: MatDialogRef<GenreDialogComponent>,
    @Inject(MAT_DIALOG_DATA) data
  ) {
    // (this.id = data.id), (this.genreName = data.name);
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      genreName: new FormControl('Teste'),
    });
  }

  save(value: string) {
    this.dialogRef.close(this.form.value);
    console.log(value);
  }

  close() {
    this.dialogRef.close();
  }
}
