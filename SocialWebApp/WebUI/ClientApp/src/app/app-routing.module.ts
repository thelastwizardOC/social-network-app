import { WildcardPageComponent } from './pages/wildcard-page/wildcard-page.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ErrorComponent } from './pages/error-page/error.component';
import { MessageComponent } from './pages/message/message.component';
import { NotificationComponent } from './pages/notification/notification.component';
import { AccessGuard } from './guard/access.guard';
import { AuthGuard } from './guard/auth.guard';

const routes: Routes = [
  {
    path: 'newsfeed',
    loadChildren: async () => (await import('./pages/newsfeed-page/newsfeed-page.module')).NewsfeedPageModule,
    canActivate: [AccessGuard]
  },
  {
    path: 'profile',
    loadChildren: async () => (await import('./pages/personal-page/personal-page.module')).PersonalPageModule,
    canActivate: [AccessGuard]
  },
  {
    path: 'auth',
    loadChildren: async () => (await import('./pages/auth/auth.module')).AuthModule,
    canActivate: [AuthGuard]
  },
  {
    path: 'message',
    component: MessageComponent
  },
  {
    path: 'notification',
    component: NotificationComponent
  },
  {
    path: 'error', component: ErrorComponent
  },
  { path: '**', component: WildcardPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
