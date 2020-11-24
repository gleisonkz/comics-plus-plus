import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { GenreService } from '../../../../../services/genre.service';
import { Genre } from '../../genre-crud/genre-crud.component';

@Component({
  templateUrl: './genre-dialog.component.html',
  styleUrls: ['./genre-dialog.component.scss'],
})
export class GenreDialogComponent implements OnInit {
  form: FormGroup;
  id: number;

  constructor(
    private dialogRef: MatDialogRef<GenreDialogComponent>,
    private genreService: GenreService,
    @Inject(MAT_DIALOG_DATA) data
  ) {
    // console.log(data);
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      description: new FormControl('', [
        Validators.required,
        Validators.minLength(3),
      ]),
    });
  }

  save() {
    this.genreService
      .postGenre(this.form.value)
      .subscribe((c) => console.log(c));

    this.dialogRef.close(this.form.value);
  }

  close() {
    this.dialogRef.close();
  }
}
