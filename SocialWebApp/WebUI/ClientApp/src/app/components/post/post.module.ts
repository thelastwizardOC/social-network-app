import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { TuiSvgModule } from '@taiga-ui/core';
import { TuiAvatarModule } from '@taiga-ui/kit';
import { DateFromNowPipe } from 'src/app/pipes/date.pipe';
import { PluralPipe } from 'src/app/pipes/plural.pipe';
import { PostComponent } from './post.component';
import { CarouselModule } from '../carousel/carousel.module';

@NgModule({
  declarations: [PostComponent, DateFromNowPipe, PluralPipe],
  imports: [CommonModule, TuiAvatarModule, TuiSvgModule, CarouselModule],
  exports: [PostComponent]
})
export class PostModule {}
