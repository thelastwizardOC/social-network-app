import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import {
  TuiButtonModule,
  TuiDataListModule,
  TuiDialogModule,
  TuiDropdownModule,
  TuiHostedDropdownModule,
  TuiLoaderModule,
  TuiSvgModule
} from '@taiga-ui/core';
import { NavigationBarComponent } from './navigation-bar.component';

@NgModule({
  declarations: [NavigationBarComponent],
  imports: [
    CommonModule,
    TuiLoaderModule,
    TuiSvgModule,
    TuiHostedDropdownModule,
    TuiDataListModule,
    RouterModule,
    TuiButtonModule,
    TuiDialogModule,
    TuiDropdownModule
  ],
  exports: [NavigationBarComponent]
})
export class NavigationBarModule {}
