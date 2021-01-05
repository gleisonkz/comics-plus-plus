import { ComicInventory } from '@admin/models';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from '@core/services';
import { ComicInventoryService } from '@core/services/comic-inventory.service';
import { tap } from 'rxjs/operators';

@Component({
  templateUrl: './comic-inventory-dialog.component.html',
  styleUrls: ['./comic-inventory-dialog.component.scss']
})
export class ComicInventoryDialogComponent implements OnInit {
  form: FormGroup;
  id: number;

  constructor(
    private dialogRef: MatDialogRef<ComicInventoryDialogComponent>,
    private comicInventoryService: ComicInventoryService,
    private notificationService: NotificationService,
    @Inject(MAT_DIALOG_DATA) private data: ComicInventory
  ) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      quantity: new FormControl(this.data.quantity, [Validators.required])
    });
  }

  save(quantity: number) {
    this.data.quantity = +quantity;
    this.comicInventoryService
      .putComicInventory(+this.data.comicID, this.form.value)
      .pipe(
        tap(() =>
          this.notificationService.showMessage(
            `O registro foi atualizado com sucesso!`
          )
        )
      )
      .subscribe((comicInventory: ComicInventory) =>
        this.dialogRef.close(comicInventory)
      );
  }

  close() {
    this.dialogRef.close();
  }
}
