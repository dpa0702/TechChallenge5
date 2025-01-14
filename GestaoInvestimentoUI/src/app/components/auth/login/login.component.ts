import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _fb: FormBuilder,
    private _toastr: ToastrService
  ) {

  }

  ngOnInit() {
    this.loginForm = this._fb.group({
      username: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  /**
   * Function - submit()
   * Use - Called when
   * @param formValue
   */
  submit(formValue: any) {
    let postData = {
      email: formValue.username,
      senha: formValue.password,
      token: ''
    };


    this._authService.login(postData).subscribe({
      next: (res: any) => {
        localStorage.setItem('token', btoa(JSON.stringify(res['token'])));

        if (res.status === 200) {
          //Write your logic after response is received
          //Store token in localStorage/SessionStorage
          this._toastr.success('Login is Successful', 'Success');
        }
      },
      error: (err: any) => {
        this._toastr.error(err.error.message, 'Error');
      },
      complete: () => {
        //Write your logic after API completion
        this._router.navigate(['home']);
      }
    })
  }

  redirectToForgetPassword() {
    this._router.navigate(['/forget-password'])
  }

  redirectToNew() {
    this._router.navigate(['/new'])
  }

}
