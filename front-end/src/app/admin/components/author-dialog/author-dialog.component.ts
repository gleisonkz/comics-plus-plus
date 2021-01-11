import { Author, AuthorResource } from '@admin/models';
import { AuthorService } from '@admin/services';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from '@core/services';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Component({
  templateUrl: './author-dialog.component.html',
  styleUrls: ['./author-dialog.component.scss']
})
export class AuthorDialogComponent implements OnInit {
  form: FormGroup;
  authorID: number;
  author: AuthorResource;

  constructor(
    private dialogRef: MatDialogRef<AuthorDialogComponent>,
    private authorService: AuthorService,
    private notificationService: NotificationService,
    @Inject(MAT_DIALOG_DATA) private data?: { authorID: number }
  ) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.minLength(3)])
    });

    if (this.data) {
      this.authorService
        .getAuthorByID(this.data.authorID)
        .subscribe((author) => {
          this.form.patchValue(author);
        });
    }
  }

  save() {
    const saveObj: { operation: string; author$: Observable<Author> } =
      this.data?.authorID > 0
        ? {
            operation: 'atualizado',
            author$: this.authorService.putAuthor(
              this.data.authorID,
              this.form.value
            )
          }
        : {
            operation: 'criado',
            author$: this.authorService.postAuthor(this.form.value)
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
