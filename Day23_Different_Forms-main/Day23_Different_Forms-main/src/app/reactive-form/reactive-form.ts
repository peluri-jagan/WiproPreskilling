import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-reactive-form',
  imports: [ReactiveFormsModule,CommonModule],
  templateUrl: './reactive-form.html',
  styleUrl: './reactive-form.css'
})
export class ReactiveForm {
  userForm = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.minLength(3)]),
    email: new FormControl('', [Validators.required, Validators.email])
  });

  onSubmit() {
    if (this.userForm.valid) {
      console.log('Reactive Form Submitted:', this.userForm.value);
      this.userForm.reset();
    } else {
      this.userForm.markAllAsTouched();//Marks every control in the form as if the user has interacted with them
      // so angular validation state touched becomes true for each conrol
    }
  }

  get name() { return this.userForm.get('name'); }
  get email() { return this.userForm.get('email'); }
}
