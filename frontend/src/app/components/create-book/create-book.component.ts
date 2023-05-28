import { BookService } from './../../services/book.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

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
    private BookService: BookService
  ) {}

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      title: ['', [Validators.required]],
      sypnosis: ['', [Validators.required]],
      releaseDate: ['', [Validators.required]],
      publisher: ['', [Validators.required]],
      genreId: ['', [Validators.required]],
      authorsId: ['', [Validators.required, Validators.minLength(1)]],
    });
  }

  closeDialog = () => this.dialogRef.close();

  onSubmit = async () => {
    console.log(this.form.value);
    if (!this.form.valid) return;

    await this.BookService.add(this.form.value);
  };
}
