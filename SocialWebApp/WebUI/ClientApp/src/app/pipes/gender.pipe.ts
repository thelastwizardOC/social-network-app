import { Pipe, PipeTransform } from '@angular/core';
import { Gender } from '../interface/user';

@Pipe({
  name: 'gender'
})
export class GenderPipe implements PipeTransform {
  transform(value: unknown, ...args: unknown[]): string {
    if (value === Gender.female) return 'Female';
    if (value === Gender.male) return 'Male';
    if (value === Gender.other) return 'Other';
    return '';
  }
}
