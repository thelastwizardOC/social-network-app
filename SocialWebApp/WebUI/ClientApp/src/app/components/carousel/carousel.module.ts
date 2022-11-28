import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CarouselComponent } from './carousel.component';
import { TuiCarouselModule } from '@taiga-ui/kit';

@NgModule({
  declarations: [CarouselComponent],
  imports: [CommonModule, TuiCarouselModule],
  exports: [CarouselComponent]
})
export class CarouselModule {}
