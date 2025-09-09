import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AttendeesService {
   private readonly apiUrl = 'http://localhost:3000/attendees';

  constructor(private readonly http: HttpClient) {}

  getAttendees(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  addAttendee(attendee: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, attendee);
  }
}
