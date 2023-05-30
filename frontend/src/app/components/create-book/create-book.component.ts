import { BookService } from './../../services/book.service';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IBookRequest } from 'src/app/interfaces/Book/IBookRequest';
import { BookValidation } from 'src/app/validations/BookValidation';
import { addValidationObject } from 'src/app/validations/addValidationObject';

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
    private validation: BookValidation
  ) {}
  form: FormGroup = new FormGroup({});

  book: IBookRequest = {
    id: undefined,
    title: '',
    sypnosis: '',
    releaseDate: new Date(),
    publisher: '',
    genreId: '',
    authorsId: [],
  };

  hasError = (key: string) => this.form.controls[key].hasError(key);
  getError = (key: string) => this.form.controls[key].getError(key);

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
