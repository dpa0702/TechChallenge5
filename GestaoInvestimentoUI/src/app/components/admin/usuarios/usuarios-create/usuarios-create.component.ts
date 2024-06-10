import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { postUsuario } from 'src/app/services/usuarios-service';
import { UsuarioModel } from 'src/app/models/usuarios.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-usuarios-create',
  templateUrl: './usuarios-create.component.html',
  styleUrls: ['./usuarios-create.component.css'],
})
export class UsuariosCreateComponent implements OnInit {
  createForm: FormGroup;
  mensagem: string = '';

  constructor(
    private formBuilder: FormBuilder,
    private spinnerService: NgxSpinnerService,
    private _router: Router,
  ) {
    this.createForm = this.formBuilder.group({
      nome: ['', Validators.required],
      email: ['', Validators.required],
      senha: ['', Validators.required],
    });
  }

  get form(): any {
    return this.createForm.controls;
  }

  ngOnInit(): void {
  }

  onSubmit(): void {
    this.spinnerService.show();

    //capturar os campos do formulário
    const request = new UsuarioModel(
      0,
      this.createForm.value.nome as string,
      this.createForm.value.email as string,
      this.createForm.value.senha as string,
    );

    //realizando o cadastro
    postUsuario(request)
      .subscribe({
        next: (data) => {
          this.mensagem = `${data}`;
          this.createForm.reset();
        },
        error: (e) => {
          this.mensagem = `Erro: ${e.response.data}`;
          console.log(e.response.data);
        },
        complete: () => {
          //Write your logic after API completion
          this._router.navigate(['usuarios/consulta-de-usuarios']);
        }
      })
      .add(() => {
        this.spinnerService.hide();
      });
  }
}
