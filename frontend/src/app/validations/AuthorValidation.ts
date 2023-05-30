import { Validator } from 'fluentvalidation-ts';
import { IAuthorRequest } from '../interfaces/Author/IAuthorRequest';
export class AuthorValidation extends Validator<IAuthorRequest> {
  constructor() {
    super();

    this.ruleFor('firstName').notEmpty().withMessage('First name is required');

    this.ruleFor('lastName').notEmpty().withMessage('Last name is required');

    this.ruleFor('address')
      .notEmpty()
      .withMessage('Address is required')
      .minLength(10)
      .withMessage('Address must be at least 10 characters');

    this.ruleFor('email')
      .notEmpty()
      .withMessage('Email is required')
      .emailAddress()
      .withMessage('Email is invalid');

    this.ruleFor('birthDate')
      .notNull()
      .withMessage('Birth date is required')
      .must((birth) => birth != new Date())
      .withMessage('Birth date must be different from today')
      .must((birth) => birth < new Date())
      .withMessage('Birth date must be less than today');
  }
}
