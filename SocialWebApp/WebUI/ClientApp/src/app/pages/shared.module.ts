import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DateFromNowPipe } from '../pipes/date.pipe';

@NgModule({
  declarations: [DateFromNowPipe],
  imports: [CommonModule],
  exports: [DateFromNowPipe]
})
export class SharedModule {}
