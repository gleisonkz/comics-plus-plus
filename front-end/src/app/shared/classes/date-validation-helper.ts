export class DateValidation {
  static isLeapYear(year: number) {
    const divisibleBy = (operand: number) => year % operand === 0;
    return (divisibleBy(4) && !divisibleBy(100)) || divisibleBy(400);
  }

  static isValidMonth(month: number) {
    const isValid = month > 0 && month <= 12;
    return isValid;
  }

  static isDatePattern(dateString: string) {
    return /^\d{1,2}\/\d{1,2}\/\d{4}$/.test(dateString);
  }

  static isValidYear(year: number) {
    const isValid = year > 0 && year <= new Date().getFullYear();
    return isValid;
  }

  static isValidDay(day: number, month: number, year: number) {
    const daysInMonth = Array.from(Array(12), (_, i) => i)
      .map((c, i) => c % 2 === +(i < 7))
      .map((c) => 30 + +!c)
      .map((c, i) => c - +(i === 1) * (+!this.isLeapYear(year) + 1));

    const isValid = day > 0 && day <= daysInMonth[month - 1];
    return isValid;
  }
}
