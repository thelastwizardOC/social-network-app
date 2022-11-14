import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import {
  TuiDataListModule,
  TuiHostedDropdownModule,
  TuiSvgModule,
} from '@taiga-ui/core';
import { NavigationBarComponent } from './navigation-bar.component';

@NgModule({
  declarations: [NavigationBarComponent],
  imports: [
    CommonModule,
    TuiSvgModule,
    TuiHostedDropdownModule,
    TuiDataListModule,
    RouterModule,
  ],
  exports: [NavigationBarComponent],
})
export class NavigationBarModule {}
