import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthLayoutComponent } from './layout/auth-layout.component';

@NgModule({
  imports: [
    RouterModule.forChild([
      {
        path: '',
        component: AuthLayoutComponent,
        title: 'OriTalk - login or sign in'
      }
    ])
  ],
  exports: [RouterModule]
})
export class AuthRoutesModule {}
