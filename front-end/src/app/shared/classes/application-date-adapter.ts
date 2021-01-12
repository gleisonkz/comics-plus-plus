import { NativeDateAdapter } from '@angular/material/core';

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

  isValidDate(dateString: string): Date | null | any {
    function isLeapYear(year: number) {
      const divisibleBy = (operand: number) => year % operand === 0;
      return (divisibleBy(4) && !divisibleBy(100)) || divisibleBy(400);
    }

    function isValidMonth(month: number) {
      const isValid = month > 0 && month <= 12;
      return isValid;
    }

    function isValidDay(day: number, month: number, year: number) {
      const daysInMonth = [
        31,
        isLeapYear(year) ? 29 : 28,
        31,
        30,
        31,
        30,
        31,
        31,
        30,
        31,
        30,
        31
      ];
      const isValid = day > 0 && day <= daysInMonth[month - 1];
      return isValid;
    }

    function isValidYear(year: number) {
      const isValid = year > 0 && year <= new Date().getFullYear();
      return isValid;
    }

    function isDatePattern(dateString: string) {
      return /^\d{1,2}\/\d{1,2}\/\d{4}$/.test(dateString);
    }

    if (!isDatePattern(dateString)) return this.invalid();

    const [day, month, year] = dateString.split('/').map(Number);

    if (!isValidYear(year)) return this.invalid();
    if (!isValidDay(day, month, year)) return this.invalid();
    if (!isValidMonth(month)) return this.invalid();

    return new Date(`${year}-${month}-${day}`);
  }
}
