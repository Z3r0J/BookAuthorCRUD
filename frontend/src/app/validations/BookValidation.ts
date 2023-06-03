import { Validator } from 'fluentvalidation-ts';
import { IBookRequest } from '../interfaces/Book/IBookRequest';
import { ValidationErrors } from '@angular/forms';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class BookValidation extends Validator<IBookRequest> {
  constructor() {
    super();

    this.ruleFor('title')
      .notEmpty()
      .withMessage('Title is required')
      .maxLength(150)
      .withMessage('Title must be less than 150 characters');

    this.ruleFor('sypnosis')
      .notEmpty()
      .withMessage('Sypnosis is required')
      .minLength(10)
      .withMessage('Sypnosis must be at least 10 characters');

    this.ruleFor('releaseDate')
      .notNull()
      .withMessage('Release date is required');

    this.ruleFor('publisher')
      .notEmpty()
      .withMessage('Publisher is required')
      .maxLength(200)
      .withMessage('Publisher must be less than 200 characters');

    this.ruleFor('authorsId')
      .notNull()
      .must(
        (authorsId) =>
          authorsId.length > 0 &&
          authorsId.filter((authorId) => authorId !== '').length > 0
      )
      .withMessage('At least one author is required');

    this.ruleFor('genreId').notEmpty().withMessage('Genre is required');
  }
}
