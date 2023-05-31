import { IBookResponse } from './../../interfaces/Book/IBookResponse';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CreateBookComponent } from '../create-book/create-book.component';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css'],
})
export class BookComponent implements OnInit {
  constructor(private dialog: MatDialog, private bookService: BookService) {}

  books: IBookResponse[] = [];

  openCreateDialog = () =>
    this.dialog.open(CreateBookComponent, {
      width: '450px',
      data: { isEdit: false, id: '' },
    });

  openEditDialog = (id: string) =>
    this.dialog.open(CreateBookComponent, {
      width: '450px',
      data: { isEdit: true, id: id },
    });

  ngOnInit(): void {
    window.document.title = 'Book - Book App';
    this.bookService.getAll().then((books) => {
      this.books = books;
    });
  }
}
