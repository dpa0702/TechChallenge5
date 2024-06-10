import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { postPortfolio } from 'src/app/services/portfolios-service';
import { PortfoliosModel } from 'src/app/models/portfolios.model';
import { Router } from '@angular/router';
import { UsuarioModel } from 'src/app/models/usuarios.model';
import { getUsuario } from 'src/app/services/usuarios-service';

@Component({
  selector: 'app-portfolios-create',
  templateUrl: './portfolios-create.component.html',
  styleUrls: ['./portfolios-create.component.css'],
})
export class PortfolioCreateComponent implements OnInit {
  createForm: FormGroup;
  mensagem: string = '';
  usuarios = [
    { id: 1, nome: 'Nome', email: 'E-mail', senha: 'Senha' }
  ];

  constructor(
    private formBuilder: FormBuilder,
    private spinnerService: NgxSpinnerService,
    private _router: Router,
  ) {
    this.createForm = this.formBuilder.group({
      usuarioID: ['', Validators.required],
      nome: ['', Validators.required],
      descricao: ['', Validators.required],
    });
  }

  get form(): any {
    return this.createForm.controls;
  }

  ngOnInit(): void {
    const request = new UsuarioModel(
      0,
      '',
      '',
      '',
    );

    getUsuario(request)
      .subscribe({
        next: (data) => {

          const model: UsuarioModel[] = [];

          data.forEach(item => {
            model.push({
              id: item.id,
              nome: item.nome,
              email: item.email,
              senha: item.senha,
            });
          });
          this.usuarios = model;
        },
        error: (e) => {
          console.log(e.error.response);
        }
      })
      .add(() => {
        this.spinnerService.hide();
      })
  }

  onSubmit(): void {
    this.spinnerService.show();

    //capturar os campos do formulário
    const request = new PortfoliosModel(
      0,
      this.createForm.value.usuarioID as number,
      this.createForm.value.nome as string,
      this.createForm.value.descricao as string,
    );

    //realizando o cadastro
    postPortfolio(request)
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
          this._router.navigate(['portfolios/consulta-de-portfolios']);
        }
      })
      .add(() => {
        this.spinnerService.hide();
      });
  }
}
