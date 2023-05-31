import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { IGenreRequest } from 'src/app/interfaces/Genre/IGenreRequest';
import { GenreService } from 'src/app/services/genre.service';
import { GenreValidation } from 'src/app/validations/GenreValidation';
import { addValidationObject } from 'src/app/validations/addValidationObject';

@Component({
  selector: 'app-create-genre',
  templateUrl: './create-genre.component.html',
  styleUrls: ['./create-genre.component.css'],
})
export class CreateGenreComponent implements OnInit {
  /**
   *
   */
  constructor(
    public dialogRef: MatDialogRef<CreateGenreComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private genreService: GenreService,
    private formBuilder: FormBuilder,
    private validation: GenreValidation
  ) {}

  form: FormGroup = new FormGroup({});

  genre = {
    id: undefined,
    name: '',
  } as IGenreRequest;

  hasError = (key: string) => this.form.controls[key].hasError(key);
  getError = (key: string) => this.form.controls[key].getError(key);

  ngOnInit(): void {
    if (this.data.isEdit) {
      this.genreService.getById(this.data.id!).then((value) => {
        this.genre = {
          id: value.id,
          name: value.name,
        };
      });
    }

    this.form = this.formBuilder.group({
      name: [this.genre.name, [Validators.required]],
    });

    this.form.valueChanges.subscribe((values: any) => {
      const errors = this.validation.validate(values);
      addValidationObject(this.form, errors);
    });
  }

  closeDialog = () => this.dialogRef.close();

  onSubmit = async () => {
    if (this.form.invalid) return;

    this.form.value.id = this.genre.id;

    this.data.isEdit
      ? await this.genreService.update(this.genre.id!, this.form.value)
      : await this.genreService.add(this.form.value);

    this.closeDialog();
  };
}
