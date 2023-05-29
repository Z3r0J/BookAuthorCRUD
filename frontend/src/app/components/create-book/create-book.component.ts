import { BookService } from './../../services/book.service';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IBookRequest } from 'src/app/interfaces/Book/IBookRequest';

@Component({
  selector: 'app-create-book',
  templateUrl: './create-book.component.html',
  styleUrls: ['./create-book.component.css'],
})
export class CreateBookComponent implements OnInit {
  form: FormGroup = new FormGroup({});

  constructor(
    public dialogRef: MatDialogRef<CreateBookComponent>,
    private formBuilder: FormBuilder,
    private BookService: BookService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  book: IBookRequest = {
    id: undefined,
    title: '',
    sypnosis: '',
    releaseDate: new Date(),
    publisher: '',
    genreId: '',
    authorsId: [],
  };

  ngOnInit(): void {
    if (this.data.isEdit) {
      this.BookService.getById(this.data.id).then((book) => {
        this.book = {
          id: book.id,
          title: book.title,
          sypnosis: book.sypnosis,
          releaseDate: new Date(book.releaseDate),
          publisher: book.publisher,
          genreId: book.genreId,
          authorsId: [],
        };
      });
    }

    this.form = this.formBuilder.group({
      title: [
        this.book.title,
        [Validators.required, Validators.maxLength(150)],
      ],
      sypnosis: [this.book.sypnosis, [Validators.required]],
      releaseDate: [this.book.releaseDate, [Validators.required]],
      publisher: [
        this.book.publisher,
        [Validators.required, Validators.maxLength(200)],
      ],
      genreId: [this.book.genreId, [Validators.required]],
      authorsId: [
        this.book.authorsId,
        [Validators.required, Validators.minLength(1)],
      ],
    });
  }

  closeDialog = () => this.dialogRef.close();

  onSubmit = async () => {
    if (!this.form.valid) return;

    this.form.value.releaseDate = new Date(
      this.form.value.releaseDate
    ).toISOString();

    this.form.value.id = this.data.id;

    this.data.isEdit
      ? await this.BookService.update(this.data.id, this.form.value)
      : await this.BookService.add(this.form.value);
  };
}
