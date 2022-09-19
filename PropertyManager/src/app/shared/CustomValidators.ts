import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export function contains(text: string): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {

    if (String(control.value).includes(text)) {
      return {'contains' : true}
    }
    return null;
  }
}
