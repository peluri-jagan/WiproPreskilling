import { Component, signal } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { TemplateForm } from "./template-form/template-form";
import { ReactiveForm } from "./reactive-form/reactive-form";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [FormsModule, ReactiveFormsModule,TemplateForm, ReactiveForm,CommonModule],
  template: `
    <form [formGroup]="myForm" (ngSubmit)="onSubmit()">
      <input formControlName="username">
      <button type="submit">Submit</button>
    </form>
  `,
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Different_Forms');
  myForm = new FormGroup({
    username: new FormControl('', Validators.required)
  });

  onSubmit() {
    console.log(this.myForm.value);
  }
}

