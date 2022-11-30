import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ISearchUserResponse, IUser } from '../interface/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUserApiUrl: string = environment.baseApi + '/user';
  constructor(private http: HttpClient) {}

  getUserInfo(userId: number): Observable<IUser> {
    return this.http.get<IUser>(this.baseUserApiUrl + `/${userId}`);
  }
  searchUserFriend(sourceUserId: number, keyword: string): Observable<IUser[]> {
    return this.http.get<IUser[]>(this.baseUserApiUrl + '/friend', {
      params: {
        sourceUserId,
        keyword
      }
    });
  }

  uploadPhoto(file: FormData, userid: number, type: string) {
    const params = new HttpParams().append('userid', userid);
    return this.http.post(this.baseUserApiUrl + `/upload-${type}`, file, {
      params,
      responseType: 'text'
    });
  }

  searchUser(userId: number, searchString: string, offset: number, limit: number) {
    return this.http.get<ISearchUserResponse>(this.baseUserApiUrl + '/search', {
      params: {
        userId,
        searchString,
        offset,
        limit
      }
    });
  }
}
