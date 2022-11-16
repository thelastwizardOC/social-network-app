import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TuiAlertModule, TuiDialogModule, TuiRootModule, TUI_SANITIZER } from '@taiga-ui/core';
import { NgDompurifySanitizer } from '@tinkoff/ng-dompurify';

import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationBarModule } from './components/navigation-bar/navigation-bar.module';
import { AuthModule } from './pages/auth/auth.module';
import { ErrorComponent } from './pages/error-page/error.component';
import { HomeModule } from './pages/home-page/home.module';
import { MessageComponent } from './pages/message/message.component';
import { NotificationComponent } from './pages/notification/notification.component';
import { PersonalPageModule } from './pages/personal-page/personal-page.module';

export function tokenGetter() {
  return localStorage.getItem('jwt');
}

@NgModule({
  declarations: [AppComponent, MessageComponent, NotificationComponent, ErrorComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AuthModule,
    BrowserAnimationsModule,
    TuiRootModule,
    TuiDialogModule,
    TuiAlertModule,
    PersonalPageModule,
    HomeModule,
    HttpClientModule,
    NavigationBarModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['localhost:7108'],
        disallowedRoutes: []
      }
    })
  ],
  providers: [{ provide: TUI_SANITIZER, useClass: NgDompurifySanitizer }],
  bootstrap: [AppComponent]
})
export class AppModule {}
