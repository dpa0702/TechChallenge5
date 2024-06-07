import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private _http:HttpClient) { }

  /**
   * Function - Login
   * Use - To Login User into the application
   * @param postData
   * @returns
   */
  login(postData : any){
    return this._http.post(environment.apiGestaoInvestimentos + '/Usuario/login', postData, {observe : 'response'});
  }


  /**
   * Function - forgetPassword()
   * Use - To recover the password
   * @param postData
   * @returns
   */
  forgetPassword(postData : any){
    return this._http.post(environment.apiGestaoInvestimentos + '/Usuario/forget', postData, {observe : 'response'})
  }
}
