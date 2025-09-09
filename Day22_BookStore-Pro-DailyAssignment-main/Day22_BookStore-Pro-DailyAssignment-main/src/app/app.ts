import { Component, signal } from '@angular/core';
import { BookComponent } from "./book/book";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [BookComponent,CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('BookStore-Pro');
  showBooks = true;
}
