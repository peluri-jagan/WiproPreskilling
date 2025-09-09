import { Component, OnInit } from '@angular/core';
import { EventsService } from '../../services/events.service';
import { CommonModule, DatePipe, UpperCasePipe } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-event-list',
  imports: [UpperCasePipe,DatePipe,RouterLink, CommonModule],
  templateUrl: './event-list.html',
  styleUrl: './event-list.css'
})
export class EventList implements OnInit{
  events: any[] = [];

  constructor(private readonly eventService: EventsService){}

  ngOnInit(): void {
    this.eventService.getEvents().subscribe(data => this.events = data);
  }

}
