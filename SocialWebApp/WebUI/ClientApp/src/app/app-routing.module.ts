import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home-page/home/home.component';

const routes: Routes = [
  {
    path: 'profile',
    loadChildren: async () =>
      (await import('./pages/personal-page/personal-page.module'))
        .PersonalPageModule,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
