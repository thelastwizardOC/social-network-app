import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeContainerComponent } from './home-container/home-container.component';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [HomeContainerComponent, HomeComponent],
  imports: [CommonModule]
})
export class HomeModule {}
