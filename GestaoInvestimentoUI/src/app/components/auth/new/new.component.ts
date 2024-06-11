import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms'
import { AuthService } from '../../../services/auth.service';
import { FormBuilder, Validators } from '@angular/forms'
import { ToastrService } from 'ngx-toastr';
import { postUsuario } from 'src/app/services/usuarios-service';
import { UsuarioModel } from 'src/app/models/usuarios.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new',
  templateUrl: './new.component.html',
  styleUrls: ['./new.component.scss']
})
export class NewComponent implements OnInit {
  newForm!: FormGroup;

  constructor(
    private _authService: AuthService,
    private _fb: FormBuilder,
    private _toastr: ToastrService,
    private _router: Router,
  ) {

  }

  ngOnInit(): void {
    this.newForm = this._fb.group({
      nome: ['', [Validators.required, ]],
      email: ['', [Validators.required, Validators.email]]
    })
  }


  submit(formValue: any) {
    //capturar os campos do formulário
    const request = new UsuarioModel(
      0,
      this.newForm.value.nome as string,
      this.newForm.value.email as string,
      'SenhaPredefinida',
    );

    //realizando o cadastro
    postUsuario(request)
      .subscribe({
        next: (data) => {
          this._toastr.success(`${data}`);
          this.newForm.reset();
        },
        error: (err: any) => {
          this._toastr.error(err.error.message, 'Error');
        },
        complete: () => {
          this._toastr.success('Email sent successfully', 'Success')
          this._router.navigate(['/']);
        }
      })
  }

}
