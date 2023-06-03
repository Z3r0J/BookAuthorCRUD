import { IBookResponse } from './../../interfaces/Book/IBookResponse';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CreateBookComponent } from '../create-book/create-book.component';
import { BookService } from 'src/app/services/book.service';
import Swal from 'sweetalert2';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css'],
})
export class BookComponent implements OnInit {
  constructor(private dialog: MatDialog, private bookService: BookService) {}

  books: IBookResponse[] = [];
  timeout: any;
  search: FormGroup = new FormGroup({
    name: new FormControl('', [Validators.required]),
  });

  openCreateDialog = () =>
    this.dialog.open(CreateBookComponent, {
      width: '450px',
      data: { isEdit: false, id: '' },
    });

  getBooks = () => {
    this.bookService.getAll().then((books) => {
      this.books = books;
    });
  };

  searchBook = (value: string) => {
    clearTimeout(this.timeout);

    this.timeout = setTimeout(() => {
      this.bookService.getAll(value).then((books) => {
        this.books = books;
      });
    }, 3000);
  };

  openEditDialog = (id: string) =>
    this.dialog.open(CreateBookComponent, {
      width: '450px',
      data: { isEdit: true, id: id },
    });

  openDeleteDialog = (id: string) =>
    Swal.fire({
      title: 'Are you sure?',
      text: 'You will not be able to recover this book!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'No, keep it',
    }).then(async (result) => {
      if (result.isConfirmed) {
        await this.bookService.delete(id);
        Swal.fire('Deleted!', 'Your book has been deleted.', 'success');
        this.getBooks();
      }
    });

  ngOnInit(): void {
    this.search.valueChanges.subscribe((values: any) => {
      this.searchBook(values.name);
    });
    this.getBooks();
    window.document.title = 'Book - Book App';
    this.dialog.afterAllClosed.subscribe(() => {
      this.getBooks();
    });
  }
}
