import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IUser } from '../interface/user';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}

  getUserInfo(userId: number): Observable<IUser> {
    return this.http.get<IUser>(`${environment.baseApi}/user/${userId}`);
  }

  uploadAvatar(base64: string, id: number) {
    const body = JSON.stringify({ id, base64 });
    const headers = {
      'content-type': 'application/json',
      'Response-Type': 'text',
    };
    return this.http.post(`${environment.baseApi}/user/upload-avatar`, body, {
      headers,
      responseType: 'text',
    });
  }
}
