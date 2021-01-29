import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'cms-confirmation-dialog',
  templateUrl: './confirmation-dialog.component.html',
  styleUrls: ['./confirmation-dialog.component.scss']
})
export class ConfirmationDialogComponent {
  message: string = 'Você tem certeza que deseja excluir o registro?';
  confirmButtonText = 'Sim';
  cancelButtonText = 'Cancelar';
  item: any;

  constructor(
    @Inject(MAT_DIALOG_DATA) private data: any,
    private dialogRef: MatDialogRef<ConfirmationDialogComponent>
  ) {
    this.item = data;
    this.message = data?.message || this.message;
    this.confirmButtonText = data?.buttonText?.ok || this.confirmButtonText;
    this.cancelButtonText = data?.buttonText?.cancel || this.cancelButtonText;
  }

  onConfirmClick(): void {
    this.dialogRef.close(true);
  }
}
