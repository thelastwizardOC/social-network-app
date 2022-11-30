import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { TuiSvgModule } from '@taiga-ui/core';
import { TuiAvatarModule } from '@taiga-ui/kit';
import { SharedModule } from 'src/app/pages/shared.module';
import { PluralPipe } from 'src/app/pipes/plural.pipe';
import { PostComponent } from './post.component';
import { CarouselModule } from '../carousel/carousel.module';

@NgModule({
  declarations: [PostComponent, PluralPipe],
  imports: [CommonModule, TuiAvatarModule, TuiSvgModule, SharedModule, CarouselModule],
  exports: [PostComponent]
})
export class PostModule {}
