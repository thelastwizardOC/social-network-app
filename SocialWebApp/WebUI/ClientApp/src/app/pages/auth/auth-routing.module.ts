import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthComponent } from './auth.component';
import { LoginComponent } from './components/login/login.component';

@NgModule({
  imports: [
    RouterModule.forChild([
      {
        path: '',
        component: AuthComponent,
        title: 'OriTalk - login or sign in',
        children: [
          {
            path: 'login',
            component: LoginComponent,
          },
        ],
      },
    ]),
  ],
  exports: [RouterModule],
})
export class AuthRoutingModule {}
