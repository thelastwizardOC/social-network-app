import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
  TuiAlertModule,
  TuiDialogModule,
  TuiRootModule,
  TUI_SANITIZER,
} from '@taiga-ui/core';
import { NgDompurifySanitizer } from '@tinkoff/ng-dompurify';

import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationBarModule } from './components/navigation-bar/navigation-bar.module';
import { HomeContainerComponent } from './pages/home-page/home-container/home-container.component';
import { HomeComponent } from './pages/home-page/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { MessageComponent } from './pages/message/message.component';
import { NewsfeedComponent } from './pages/newsfeed/newsfeed.component';
import { NotificationComponent } from './pages/notification/notification.component';
import { PersonalPageModule } from './pages/personal-page/personal-page.module';
import { PersonalWallComponent } from './pages/personal-wall/personal-wall.component';
import { RegisterComponent } from './pages/register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeContainerComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    NewsfeedComponent,
    PersonalWallComponent,
    MessageComponent,
    NotificationComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    TuiRootModule,
    TuiDialogModule,
    TuiAlertModule,
    PersonalPageModule,
    HttpClientModule,
    NavigationBarModule,
  ],
  providers: [{ provide: TUI_SANITIZER, useClass: NgDompurifySanitizer }],
  bootstrap: [AppComponent],
})
export class AppModule {}
