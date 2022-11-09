import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import {
  TuiDataListModule,
  TuiDropdownModule,
  TuiHostedDropdownModule,
  TuiLinkModule,
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
    TuiDropdownModule,
    TuiLinkModule,
    RouterModule,
  ],
  exports: [NavigationBarComponent],
})
export class NavigationBarModule {}
