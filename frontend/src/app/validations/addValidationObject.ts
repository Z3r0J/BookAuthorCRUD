import { FormGroup } from '@angular/forms';
import { ValidationErrors } from 'fluentvalidation-ts';

export const addValidationObject = (
  formGroup: FormGroup<any>,
  validationErrors: ValidationErrors<any>
): void => {
  Object.keys(validationErrors).forEach((key) => {
    formGroup.controls[key].setErrors({ [key]: validationErrors[key] });
  });
};
