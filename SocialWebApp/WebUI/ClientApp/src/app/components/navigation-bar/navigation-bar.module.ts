import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { TuiSvgModule } from '@taiga-ui/core';
import { NavigationBarComponent } from './navigation-bar.component';

@NgModule({
  declarations: [NavigationBarComponent],
  imports: [CommonModule, TuiSvgModule],
  exports: [NavigationBarComponent],
})
export class NavigationBarModule {}
