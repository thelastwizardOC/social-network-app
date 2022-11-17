import { Pipe, PipeTransform } from '@angular/core';
import * as moment from 'moment';

@Pipe({
  name: 'dateFromNow'
})
export class DateFromNowPipe implements PipeTransform {
  transform(value: Date, ...args: unknown[]): unknown {
    moment.relativeTimeThreshold('s', 60);
    moment.relativeTimeThreshold('m', 60);
    moment.relativeTimeThreshold('h', 24);
    var today = new Date();
    var timeDifference = Math.abs(today.getTime() - new Date(value).getTime());
    var differenceDays = Math.floor(timeDifference / (1000 * 3600 * 24));

    if (differenceDays <= 7) {
      return moment(value).fromNow();
    }
    console.log({ value });
    return moment(value).format('DD/MM/YYYY - HH:mm');
  }
}
