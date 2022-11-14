import { AbstractControl, Validators } from '@angular/forms';

const userNameChars = /^[A-Za-z][a-zA-Z0-9]+$/;
const passwordChars = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$/;

export function userNameValidator(field: AbstractControl): Validators | null {
  if (!field.value) return { other: `Please enter your user name` };
  if (!userNameChars.test(field.value))
    return {
      other: `The user name is invalid. Please use another one which not start with a number and not contain special characters, spaces or symbols`,
    };
  if (field.value.length < 5)
    return {
      other: `The user name must be at least 5 characters long. Please use another one`,
    };
  if (field.value.length > 32)
    return {
      other: `The user name is limited on the number of 32 characters. Please use another one`,
    };
  return null;
}

export function passwordValidator(field: AbstractControl): Validators | null {
  if (!field.value) return { other: `Please enter your password` };
  if (!passwordChars.test(field.value))
    return {
      other: `Please enter your password with at least 1 uppercase, 1 lowercase and 1 number `,
    };
  if (field.value.length < 8)
    return {
      other: `The password must be at least 8 characters long. Please use another one`,
    };
  if (field.value.length > 32)
    return {
      other: `The password is limited on the number of 32 characters. Please use another one`,
    };
  return null;
}
