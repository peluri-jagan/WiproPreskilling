import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../models/book.model';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  //Created a mock api using mockapi.io
  private readonly apiUrl = 'https://689cbad758a27b18087f43ca.mockapi.io/books';

  constructor(private readonly http:HttpClient){}

  getBooks():Observable<Book[]>{
    return this.http.get<Book[]>(this.apiUrl);
  }
}
