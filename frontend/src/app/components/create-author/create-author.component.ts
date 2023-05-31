import { addValidationObject } from './../../validations/addValidationObject';
import {
  FormControl,
  FormGroup,
  FormBuilder,
  Validators,
} from '@angular/forms';
import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { IAuthorRequest } from 'src/app/interfaces/Author/IAuthorRequest';
import { AuthorService } from 'src/app/services/author.service';
import { AuthorValidation } from 'src/app/validations/AuthorValidation';

@Component({
  selector: 'app-create-author',
  templateUrl: './create-author.component.html',
  styleUrls: ['./create-author.component.css'],
})
export class CreateAuthorComponent implements OnInit {
  /**
   *
   */
  constructor(
    public dialogRef: MatDialogRef<CreateAuthorComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public authorService: AuthorService,
    private formBuilder: FormBuilder,
    private validation: AuthorValidation
  ) {}

  form: FormGroup = new FormGroup({});

  author: IAuthorRequest = {
    id: undefined,
    firstName: '',
    lastName: '',
    address: '',
    email: '',
    birthDate: new Date(),
  };

  hasError = (key: string) => this.form.controls[key].hasError(key);
  getError = (key: string) => this.form.controls[key].getError(key);

  ngOnInit(): void {
    if (this.data.isEdit) {
      this.authorService.getById(this.data.id!).then((value) => {
        this.author = {
          id: value.id,
          firstName: value.firstName,
          lastName: value.lastName,
          address: value.address,
          email: value.email,
          birthDate: value.birthDate,
        };
      });
    }
    this.form = this.formBuilder.group({
      firstName: [this.author.firstName, [Validators.required]],
      lastName: [this.author.lastName, [Validators.required]],
      address: [this.author.address, [Validators.required]],
      email: [this.author.email, [Validators.required]],
      birthDate: [this.author.birthDate, [Validators.required]],
    });

    this.form.valueChanges.subscribe((values: any) => {
      const errors = this.validation.validate(values);
      addValidationObject(this.form, errors);
    });
  }

  onSubmit = () => {};
}
