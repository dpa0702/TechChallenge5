import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private _http: HttpClient,
    private _router: Router,
  ) { }

  /**
   * Function - Login
   * Use - To Login User into the application
   * @param postData
   * @returns
   */
  login(postData: any) {
    return this._http.post(environment.apiGestaoInvestimentos + '/Usuario/login', postData, { observe: 'response' });
  }


  /**
   * Function - forgetPassword()
   * Use - To recover the password
   * @param postData
   * @returns
   */
  forgetPassword(postData: any) {
    return this._http.post(environment.apiGestaoInvestimentos + '/Usuario/forget', postData, { observe: 'response' })
  }

  /**
   * Function - forgetPassword()
   * Use - To recover the password
   * @param postData
   * @returns
   */
  new(postData: any) {
    return this._http.post(environment.apiGestaoInvestimentos + '/Usuario/new', postData, { observe: 'response' })
  }

  hasAccess() {
    return localStorage.getItem('token') ? true : false;
  }

  redirecionaLogin(){
    this._router.navigate(['home']);
  }

}
