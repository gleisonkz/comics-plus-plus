import { MatDialogConfig } from '@angular/material/dialog';

export function createMatDialogConfig({
  data = null,
  disableClose = true,
  autoFocus = true,
  hasBackdrop = true
}) {
  const dialogConfig = new MatDialogConfig();

  dialogConfig.disableClose = disableClose;
  dialogConfig.autoFocus = autoFocus;
  dialogConfig.hasBackdrop = hasBackdrop;
  dialogConfig.data = data;
  return dialogConfig;
}
