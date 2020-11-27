import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/services/notification.service';
import { ComicService } from '../../../../../services/comic.service';
import { Comic } from '../../../../../models/comic.model';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Component({
  templateUrl: './comic-dialog.component.html',
  styleUrls: ['./comic-dialog.component.scss'],
})
export class ComicDialogComponent implements OnInit {
  form: FormGroup;
  id: number;
  imagePreview;

  constructor(
    private dialogRef: MatDialogRef<ComicDialogComponent>,
    private comicService: ComicService,
    private notificationService: NotificationService,
    @Inject(MAT_DIALOG_DATA) private data: Comic
  ) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      title: new FormControl(this.data?.title || '', [
        Validators.required,
        Validators.minLength(3),
      ]),
      description: new FormControl(this.data?.title || '', [
        Validators.required,
        Validators.minLength(3),
      ]),
      price: new FormControl(this.data?.title || '', [
        Validators.required,
        Validators.minLength(3),
      ]),
      year: new FormControl(this.data?.title || '', [
        Validators.required,
        Validators.minLength(3),
      ]),
      pages: new FormControl(this.data?.title || '', [
        Validators.required,
        Validators.minLength(3),
      ]),
      authors: new FormControl(this.data?.title || '', [
        Validators.required,
        Validators.minLength(3),
      ]),
      genres: new FormControl(this.data?.title || '', [
        Validators.required,
        Validators.minLength(3),
      ]),
      image: new FormControl(this.data?.title || '', [
        Validators.required,
        Validators.minLength(3),
      ]),
    });

    this.getPreviewImage();
  }

  getPreviewImage(): void {
    this.form.controls['image'].valueChanges.subscribe((c) => {
      const file = c.files[0];
      this.readFile(file).subscribe((c) => (this.imagePreview = c));
    });
  }

  save() {
    const saveObj: { operation: string; author$: Observable<Comic> } =
      this.data?.comicID > 0
        ? {
            operation: 'atualizado',
            author$: this.comicService.putComic(
              this.data.comicID,
              this.form.value
            ),
          }
        : {
            operation: 'criado',
            author$: this.comicService.postComic(this.form.value),
          };

    saveObj.author$
      .pipe(
        tap(() =>
          this.notificationService.showMessage(
            `O registro foi ${saveObj.operation} com sucesso!`
          )
        )
      )
      .subscribe((author: Comic) => this.dialogRef.close(author));
  }

  close() {
    this.dialogRef.close();
  }

  readFile(file: File): Observable<string | ArrayBuffer> {
    const temporaryFileReader = new FileReader();

    return new Observable<string | ArrayBuffer>((publisher) => {
      temporaryFileReader.onload = () => {
        publisher.next(temporaryFileReader.result);
      };

      temporaryFileReader.onerror = () => {
        temporaryFileReader.abort();
        publisher.error('Problem parsing with file.');
      };

      temporaryFileReader.readAsDataURL(file);
    });
  }
}
