import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IPersonalPostResponse } from '../interface/personal-post';

@Injectable({
  providedIn: 'root',
})
export class PersonalPostService {
  constructor(private http: HttpClient) {}

  getPersonalPost(
    userId: number,
    offset: number = 0,
    limit: number = 10
  ): Observable<IPersonalPostResponse> {
    return this.http.get<IPersonalPostResponse>(
      `${environment.baseApi}/post/${userId}`,
      {
        params: {
          limit,
          offset,
        },
      }
    );
  }
}
