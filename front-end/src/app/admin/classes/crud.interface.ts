import { FormGroup } from '@angular/forms';
export interface BaseCrud {
  openDialog(): void;
  loadData<T>(obj: T): void;
  form: FormGroup;
  title: string;
}
