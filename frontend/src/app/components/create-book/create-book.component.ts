import { IAuthorResponse } from './../../interfaces/Author/IAuthorResponse';
import { BookService } from './../../services/book.service';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IBookRequest } from 'src/app/interfaces/Book/IBookRequest';
import { IGenreResponse } from 'src/app/interfaces/Genre/IGenreResponse';
import { AuthorService } from 'src/app/services/author.service';
import { GenreService } from 'src/app/services/genre.service';
import { BookValidation } from 'src/app/validations/BookValidation';
import { addValidationObject } from 'src/app/validations/addValidationObject';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-create-book',
  templateUrl: './create-book.component.html',
  styleUrls: ['./create-book.component.css'],
})
export class CreateBookComponent implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<CreateBookComponent>,
    private formBuilder: FormBuilder,
    private BookService: BookService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private validation: BookValidation,
    private authorService: AuthorService,
    private genreService: GenreService
  ) {}
  form: FormGroup = new FormGroup({});

  book: IBookRequest = {} as IBookRequest;

  authors: IAuthorResponse[] = [];
  genres: IGenreResponse[] = [];

  hasError = (key: string) => this.form.controls[key].hasError(key);
  getError = (key: string) => this.form.controls[key].getError(key);

  ngOnInit(): void {
    if (this.data.isEdit) {
      this.BookService.getById(this.data.id).then((book) => {
        this.form.patchValue(book);
      });
    }

    this.authorService.getAll().then((authors) => {
      this.authors = authors;
    });

    this.genreService.getAll().then((genres) => {
      this.genres = genres;
    });

    this.form = this.formBuilder.group({
      title: [this.book.title, [Validators.required]],
      sypnosis: [this.book.sypnosis, [Validators.required]],
      releaseDate: [this.book.releaseDate, [Validators.required]],
      publisher: [this.book.publisher, [Validators.required]],
      genreId: [this.book.genreId, [Validators.required]],
      authorsId: [this.book.authorsId, [Validators.required]],
    });

    this.form.valueChanges.subscribe((values: any) => {
      const errors = this.validation.validate(values);
      addValidationObject(this.form, errors);
    });
  }

  closeDialog = () => this.dialogRef.close();

  onSubmit = () => {
    this.form.value.authorsId = this.form.value.authorsId!.filter(
      (x: string) => x.length > 0
    );
    if (this.form.invalid) return;

    this.form.value.releaseDate = new Date(
      this.form.value.releaseDate
    ).toISOString();

    this.form.value.id = this.data.id;

    this.data.isEdit
      ? this.BookService.update(this.data.id, this.form.value)
          .then(() => {
            Swal.fire(
              'Updated!',
              'The book was updated successfully.',
              'success'
            );
            this.closeDialog();
          })
          .catch(() => {
            Swal.fire('Error!', 'The book could not be updated.', 'error');
          })
      : this.BookService.add(this.form.value)
          .then(() => {
            Swal.fire('Added!', 'The book was added successfully.', 'success');
            this.closeDialog();
          })
          .catch(() => {
            Swal.fire('Error!', 'The book could not be added.', 'error');
          });
  };
}
