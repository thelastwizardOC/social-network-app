import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import {
  TuiButtonModule,
  TuiDataListModule, TuiDialogModule,
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
    TuiButtonModule,
    TuiDialogModule,
  ],
  exports: [NavigationBarComponent],
})
export class NavigationBarModule {}
