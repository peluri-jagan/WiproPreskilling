import { Routes } from '@angular/router';
import { EventList } from './events/event-list/event-list';
import { EventCreate } from './events/event-create/event-create';
import { EventDetail } from './events/event-detail/event-detail';
import { AttendeeList } from './attendees/attendee-list/attendee-list';

export const routes: Routes = [
    { path: '', redirectTo: 'events', pathMatch: 'full' },
    { path: 'events', component: EventList },
    { path: 'events/create', component: EventCreate },
    { path: 'events/:id', component: EventDetail },
    { path: 'attendees', component: AttendeeList }
];
