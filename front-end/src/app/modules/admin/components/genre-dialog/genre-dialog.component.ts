import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Genre } from 'src/app/models/genre.model';
import { GenreService } from 'src/app/services/genre.service';
import { NotificationService } from 'src/app/services/notification.service';

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
    @Inject(MAT_DIALOG_DATA) private data: Genre
  ) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      description: new FormControl(this.data?.description || '', [
        Validators.required,
        Validators.minLength(3),
      ]),
    });
  }

  save() {
    const saveObj: { operation: string; genre$: Observable<Genre> } =
      this.data?.genreID > 0
        ? {
            operation: 'atualizado',
            genre$: this.genreService.putGenre(
              this.data.genreID,
              this.form.value
            ),
          }
        : {
            operation: 'criado',
            genre$: this.genreService.postGenre(this.form.value),
          };

    saveObj.genre$
      .pipe(
        tap(() =>
          this.notificationService.showMessage(
            `O registro foi ${saveObj.operation} com sucesso!`
          )
        )
      )
      .subscribe((genre: Genre) => this.dialogRef.close(genre));
  }

  close() {
    this.dialogRef.close();
  }
}
