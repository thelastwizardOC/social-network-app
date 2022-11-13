import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IAuthenticationResponse } from '../interface/login-user';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient) {}

  login(
    username: string,
    password: string
  ): Observable<IAuthenticationResponse> {
    const body = JSON.stringify({ username, password });
    const headers = { 'content-type': 'application/json' };
    return this.http.post<IAuthenticationResponse>(
      `${environment.baseApi}/authentication/login`,
      body,
      {
        headers,
      }
    );
  }

  async tryRefreshingTokens(token: string): Promise<boolean> {
    const refreshToken = localStorage.getItem('refreshToken');
    if (!token || !refreshToken) {
      return false;
    }

    const credentials = JSON.stringify({
      accessToken: token,
      refreshToken: refreshToken,
    });
    let isRefreshSuccess: boolean;
    const refreshRes = await new Promise<IAuthenticationResponse>(
      (resolve, reject) => {
        this.http
          .post<IAuthenticationResponse>(
            `${environment.baseApi}/authentication/refresh`,
            credentials,
            {
              headers: new HttpHeaders({
                'Content-Type': 'application/json',
              }),
            }
          )
          .subscribe({
            next: (res: IAuthenticationResponse) => resolve(res),
            error: (_) => {
              reject;
              isRefreshSuccess = false;
            },
          });
      }
    );
    localStorage.setItem('jwt', refreshRes.accessToken);
    localStorage.setItem('refreshToken', refreshRes.refreshToken);
    isRefreshSuccess = true;
    return isRefreshSuccess;
  }
}
