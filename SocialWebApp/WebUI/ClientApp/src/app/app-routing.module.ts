import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { MessageComponent } from './pages/message/message.component';
import { NewsfeedComponent } from './pages/newsfeed/newsfeed.component';
import { NotificationComponent } from './pages/notification/notification.component';
import { RegisterComponent } from './pages/register/register.component';
import { AccessGuard } from './guard/access.guard';
import { AuthGuard } from './guard/auth.guard';

const routes: Routes = [
  {
    path: 'profile',
    loadChildren: async () =>
      (await import('./pages/personal-page/personal-page.module'))
        .PersonalPageModule,
    canActivate: [AccessGuard],
  },
  {
    path: 'auth',
    loadChildren: async () =>
      (await import('./pages/auth/auth.module')).AuthModule,
    canActivate: [AuthGuard],
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'newsfeed',
    component: NewsfeedComponent,
  },
  {
    path: 'message',
    component: MessageComponent,
  },
  {
    path: 'notification',
    component: NotificationComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
