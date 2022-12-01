import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ISearchFriendResponse, ISearchUserResponse, IUser } from '../interface/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUserApiUrl: string = environment.baseApi + '/user';
  constructor(private http: HttpClient) {}

  getUserInfo(userId: number): Observable<IUser> {
    return this.http.get<IUser>(this.baseUserApiUrl + `/${userId}`);
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

  searchFriends(userId: number, searchString: string, offset: number = 0, limit: number = 100) {
    return this.http.get<ISearchFriendResponse>(`${environment.baseApi}/user/search-friend`, {
      params: {
        userId,
        searchString,
        offset,
        limit
      }
    });
  }
}
