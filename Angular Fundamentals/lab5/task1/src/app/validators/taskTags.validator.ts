import { AbstractControl, ValidationErrors } from '@angular/forms';

export function TaskTagsValidator(control: AbstractControl): ValidationErrors | null {
  const tags: string = control?.value;

  const tagsArray = tags.split(' ');

  for (let tag of tagsArray) {
    if (!tag.startsWith('#') || !/^#[a-zA-Z0-9]+$/.test(tag)) {
      return { invalidTag: true };
    }
  }

  return null;
}
