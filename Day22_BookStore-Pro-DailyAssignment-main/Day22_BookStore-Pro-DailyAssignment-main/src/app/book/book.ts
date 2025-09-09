import { Component, OnDestroy, OnInit } from '@angular/core';
import { DataService } from '../services/data.service';
import { Book } from '../models/book.model';
import { CommonModule } from '@angular/common';
import { Observable, Subscription } from 'rxjs';
import { BookItem } from "../book-item/book-item";

@Component({
  selector: 'app-book',
  imports: [CommonModule, BookItem],
  templateUrl: './book.html',
  styleUrl: './book.css'
})
export class BookComponent implements OnInit, OnDestroy {

  books: Book[] = [];
  books$!: Observable<Book[]>;
  private  subscription!: Subscription;

  constructor(private readonly dataService: DataService) { }

  ngOnInit(): void {
    this.books$ = this.dataService.getBooks();
    this.subscription = this.books$.subscribe({
      next: (data) => {
        this.books = data;
      },
      error: (err) => console.error('Error fetching books:', err)
    });
  }
  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
      console.log('%cBooksComponent subscription cleaned up.', 'color: green');
    }
  }

}
