import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Author } from 'src/app/models/author.model';
import { NotificationService } from 'src/app/modules/shared/services/notification.service';
import { AuthorService } from 'src/app/services/author.service';

@Component({
  templateUrl: './author-dialog.component.html',
  styleUrls: ['./author-dialog.component.scss'],
})
export class AuthorDialogComponent implements OnInit {
  form: FormGroup;
  id: number;

  constructor(
    private dialogRef: MatDialogRef<AuthorDialogComponent>,
    private authorService: AuthorService,
    private notificationService: NotificationService,
    @Inject(MAT_DIALOG_DATA) private data: Author
  ) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl(this.data?.name || '', [
        Validators.required,
        Validators.minLength(3),
      ]),
    });
  }

  save() {
    const saveObj: { operation: string; author$: Observable<Author> } =
      this.data?.authorID > 0
        ? {
            operation: 'atualizado',
            author$: this.authorService.putAuthor(
              this.data.authorID,
              this.form.value
            ),
          }
        : {
            operation: 'criado',
            author$: this.authorService.postAuthor(this.form.value),
          };

    saveObj.author$
      .pipe(
        tap(() =>
          this.notificationService.showMessage(
            `O registro foi ${saveObj.operation} com sucesso!`
          )
        )
      )
      .subscribe((author: Author) => this.dialogRef.close(author));
  }

  close() {
    this.dialogRef.close();
  }
}
