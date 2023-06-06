import { Injectable } from '@angular/core';
import { Validator } from 'fluentvalidation-ts';
import { IGenreRequest } from '../interfaces/Genre/IGenreRequest';

@Injectable({
  providedIn: 'root',
})
export class GenreValidation extends Validator<IGenreRequest> {
  constructor() {
    super();

    this.ruleFor('name')
      .notEmpty()
      .withMessage('Name is required')
      .maxLength(100)
      .withMessage('Name must be between 1 to 100 characters');
  }
}
