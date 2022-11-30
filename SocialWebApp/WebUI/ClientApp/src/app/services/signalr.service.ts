import { JwtHelperService } from '@auth0/angular-jwt';
import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { environment } from './../../environments/environment';
import { INotification } from '../interface/notification';
@Injectable({
  providedIn: 'root'
})
export class SignalrService {
  constructor() {}

  private hubConnection!: signalR.HubConnection;
  public notification!: INotification;
  startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(`${environment.baseUrl}/notificationService`, { accessTokenFactory: () => localStorage.getItem('jwt') as string })
      .build();
    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err));
  };

  addFriendListener = () => {
    this.hubConnection.on('addFriendNotification', res => {
      this.notification = res;
    });
  };
}
