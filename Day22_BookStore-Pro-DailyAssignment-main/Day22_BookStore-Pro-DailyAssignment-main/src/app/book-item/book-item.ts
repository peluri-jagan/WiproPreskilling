import { Component, Input } from '@angular/core';
import { Book } from '../models/book.model';
import { CurrencyPipe, DatePipe, SlicePipe, UpperCasePipe } from '@angular/common';
import { DiscountPipe } from '../pipes/discount-pipe';

@Component({
  selector: 'app-book-item',
  imports: [UpperCasePipe,CurrencyPipe,DatePipe,SlicePipe,DiscountPipe],
  templateUrl: './book-item.html',
  styleUrl: './book-item.css'
})
export class BookItem {
  @Input() book!: Book;
}
