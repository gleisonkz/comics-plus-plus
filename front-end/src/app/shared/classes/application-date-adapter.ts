import { NativeDateAdapter } from '@angular/material/core';
import { DateValidation } from './date-validation-helper';

export class ApplicationDateAdapter extends NativeDateAdapter {
  format(date: Date, displayFormat: Object) {
    if (displayFormat === 'input') {
      const day = date.getDate();
      const month = (date.getMonth() + 1).toString();
      const year = date.getFullYear();
      return `${day}/${month.padStart(2, '0')}/${year}`;
    }
    return date.toDateString();
  }

  parse(value: any): Date | null {
    return this.isValidDate(value);
  }

  isValidDate(dateString: string): Date {
    if (!DateValidation.isDatePattern(dateString)) return this.invalid();

    const [day, month, year] = dateString.split('/').map(Number);

    if (!DateValidation.isValidYear(year)) return this.invalid();
    if (!DateValidation.isValidDay(day, month, year)) return this.invalid();
    if (!DateValidation.isValidMonth(month)) return this.invalid();

    return new Date(`${year}-${month}-${day}`);
  }
}
