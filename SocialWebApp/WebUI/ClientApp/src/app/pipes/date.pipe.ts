import { Pipe, PipeTransform } from '@angular/core';
import * as moment from 'moment';
@Pipe({
  name: 'dateFromNow',
})
export class DateFromNowPipe implements PipeTransform {
  transform(value: Date, ...args: unknown[]): unknown {
    return moment(value).fromNow();
  }
}
