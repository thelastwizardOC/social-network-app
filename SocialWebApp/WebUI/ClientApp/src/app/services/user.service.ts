import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IUser } from '../interface/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) {}

  getUserInfo(userId: number): Observable<IUser> {
    return this.http.get<IUser>(`${environment.baseApi}/user/${userId}`);
  }

  uploadPhoto(file: FormData, userid: number, type: string) {
    const params = new HttpParams().append('userid', userid);
    return this.http.post(`${environment.baseApi}/user/upload-${type}`, file, {
      params,
      responseType: 'text'
    });
  }

  searchUser(userId: number, searchString: string) {
    return this.http.get(`${environment.baseApi}/user/search`, {
      params: {
        userId,
        searchString
      }
    });
  }
}
