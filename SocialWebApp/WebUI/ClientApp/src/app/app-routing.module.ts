import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home-page/home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
<<<<<<< HEAD
import { HomeComponent } from './pages/home-page/home/home.component';

const routes: Routes = [
  {
    path: 'profile',
    loadChildren: async () =>
      (await import('./pages/personal-page/personal-page.module'))
        .PersonalPageModule,
=======
import { RegisterComponent } from './pages/register/register.component';
import { NewsfeedComponent } from './pages/newsfeed/newsfeed.component';
import { PersonalWallComponent } from './pages/personal-wall/personal-wall.component';
import { MessageComponent } from './pages/message/message.component';
import { NotificationComponent } from './pages/notification/notification.component';

const routes: Routes = [
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
    path: 'personal-wall',
    component: PersonalWallComponent,
  },
  {
    path: 'message',
    component: MessageComponent,
  },
  {
    path: 'notification',
    component: NotificationComponent,
>>>>>>> 005f686 (add navigation)
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
