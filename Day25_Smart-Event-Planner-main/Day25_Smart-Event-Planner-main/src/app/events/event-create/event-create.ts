import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { EventsService } from '../../services/events.service';

@Component({
  selector: 'app-event-create',
  imports: [ReactiveFormsModule],
  templateUrl: './event-create.html',
  styleUrl: './event-create.css'
})
export class EventCreate {
  eventForm!: FormGroup;

  constructor(private readonly fb: FormBuilder, private readonly eventService: EventsService) {
    this.eventForm = this.fb.group({
      title: ['', Validators.required],
      date: ['', Validators.required],
      maxAttendees: [0, [Validators.required, Validators.min(1)]]
    });
  }

  onSubmit() {
    if (this.eventForm.valid) {
      this.eventService.addEvent(this.eventForm.value).subscribe(() => {
        alert('Event Created!');
        this.eventForm.reset();
      });
    }
  }
}
