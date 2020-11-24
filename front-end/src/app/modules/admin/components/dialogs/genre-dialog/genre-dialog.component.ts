import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { GenreService } from '../../../../../services/genre.service';
import { NotificationService } from '../../../../../services/notification.service';

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
    private notificationService: NotificationService,
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
      .subscribe((genre) => this.dialogRef.close(genre));
  }

  close() {
    this.dialogRef.close();
  }
}
