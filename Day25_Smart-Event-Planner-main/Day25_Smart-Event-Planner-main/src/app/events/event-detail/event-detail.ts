import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AttendeesService } from '../../services/attendees.service';
import { EventsService } from '../../services/events.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-event-detail',
  imports: [CommonModule, FormsModule],
  templateUrl: './event-detail.html',
  styleUrl: './event-detail.css'
})
export class EventDetail implements OnInit {
  event: any;

  constructor(
    private readonly route: ActivatedRoute,
    private readonly eventService: EventsService,
    private readonly attendeeService: AttendeesService
  ) { }


  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id')!;
    this.eventService.getEventById(id).subscribe(data => this.event = data);
  }

  register(formValue: any) {
    const attendee = {
      name: formValue.name,
      email: formValue.email,
      eventId: this.event.id
    };
    this.attendeeService.addAttendee(attendee).subscribe(() => {
      alert('Registered Successfully!');
    });
  }

}
