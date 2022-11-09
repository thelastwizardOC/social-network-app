import { Pipe, PipeTransform } from '@angular/core';
import { Gender } from '../interface/user';

@Pipe({
  name: 'gender',
})
export class GenderPipe implements PipeTransform {
  transform(value: unknown, ...args: unknown[]): string {
    return value === Gender.male ? 'Male' : 'Female';
  }
}
