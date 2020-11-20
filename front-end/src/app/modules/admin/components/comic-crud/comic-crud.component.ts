import { Component, NgZone, OnInit, ViewChild } from '@angular/core';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatChipInputEvent } from '@angular/material/chips';

export interface Subject {
  name: string;
}

@Component({
  selector: 'cms-comic-crud',
  templateUrl: './comic-crud.component.html',
  styleUrls: ['./comic-crud.component.scss'],
})
export class ComicCrudComponent implements OnInit {
  constructor(
    public fb: FormBuilder,
    private router: Router,
    private ngZone: NgZone
  ) {}

  visible = true;
  selectable = true;
  removable = true;
  addOnBlur = true;
  @ViewChild('chipList') chipList;
  @ViewChild('resetStudentForm') myNgForm;
  readonly separatorKeysCodes: number[] = [ENTER, COMMA];
  studentForm: FormGroup;
  subjectArray: Subject[] = [];
  SectioinArray: any = ['A', 'B', 'C', 'D', 'E'];

  ngOnInit(): void {}

  /* Reactive book form */
  submitBookForm() {
    this.studentForm = this.fb.group({
      student_name: ['', [Validators.required]],
      student_email: ['', [Validators.required]],
      section: ['', [Validators.required]],
      subjects: [this.subjectArray],
      dob: ['', [Validators.required]],
      gender: ['Male'],
    });
  }

  /* Add dynamic languages */
  add(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;
    // Add language
    if ((value || '').trim() && this.subjectArray.length < 5) {
      this.subjectArray.push({ name: value.trim() });
    }
    // Reset the input value
    if (input) {
      input.value = '';
    }
  }

  /* Remove dynamic languages */
  remove(subject: Subject): void {
    const index = this.subjectArray.indexOf(subject);
    if (index >= 0) {
      this.subjectArray.splice(index, 1);
    }
  }

  /* Date */
  formatDate(e) {
    var convertDate = new Date(e.target.value).toISOString().substring(0, 10);
    this.studentForm.get('dob').setValue(convertDate, {
      onlyself: true,
    });
  }

  /* Submit book */
  submitStudentForm() {
    // if (this.studentForm.valid) {
    //   this.studentApi.AddStudent(this.studentForm.value).subscribe((res) => {
    //     this.ngZone.run(() => this.router.navigateByUrl('/students-list'));
    //   });
    // }
  }
}
