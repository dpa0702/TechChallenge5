import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';
import { PortfoliosModel } from 'src/app/models/portfolios.model';
import { getPortfolio, deletPortfolio } from 'src/app/services/portfolios-service';
import { UsuarioModel } from 'src/app/models/usuarios.model';
import { getUsuario } from 'src/app/services/usuarios-service';

@Component({
  selector: 'app-portfolios-list',
  templateUrl: './portfolios-list.component.html',
  styleUrls: ['./portfolios-list.component.css']
})
export class PortfoliosListComponent implements OnInit {

  //mome das colunas do grid (DataTable) no material
  colunas: string[] = ['id', 'usuarioId', 'nome', 'descricao', 'actions'];

  //dados preenchidos na tabela
  dataTable = new MatTableDataSource<PortfoliosModel>();

  //formulário
  listForm: FormGroup;

  //exibição de mensagem:
  mensagem: string = '';
  usuarios = [
    { id: 1, nome: 'Nome', email: 'E-mail', senha: 'Senha' }
  ];

  constructor(
    private formBuilder: FormBuilder,
    private spinnerService: NgxSpinnerService,
    private _router: Router,
  ) {
    this.listForm = this.formBuilder.group({
      id: null,
      usuarioId: null,
      nome: [''],
      descricao: [''],
    })
  }

  ngOnInit() {
    this.spinnerService.show();

    const requestP = new PortfoliosModel(
      this.listForm.value.id,
      this.listForm.value.usuarioId as number,
      this.listForm.value.nome as string,
      this.listForm.value.descricao as string,
    );

    getPortfolio(requestP)
      .subscribe({
        next: (data) => {

          const model: PortfoliosModel[] = [];

          data.forEach(item => {
            model.push({
              id: item.id,
              usuarioId: item.usuarioId,
              nome: item.nome,
              descricao: item.descricao
            });
          });

          this.dataTable.data = model;

        },
        error: (e) => {
          console.log(e.error.response);
        }
      })
      .add(() => {
        this.spinnerService.hide();
      });

    const requestU = new UsuarioModel(
      0,
      '',
      '',
      '',
    );

    getUsuario(requestU)
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
      });
  }

  get form(): any {
    return this.listForm.controls;
  }

  onSubmit(): void {
    this.spinnerService.show();

    const requestP = new PortfoliosModel(
      this.listForm.value.id,
      this.listForm.value.usuarioId as number,
      this.listForm.value.nome as string,
      this.listForm.value.descricao as string,
    );

    getPortfolio(requestP)
      .subscribe({
        next: (data) => {

          const model: PortfoliosModel[] = [];

          data.forEach(item => {
            model.push({
              id: item.id,
              usuarioId: item.usuarioId,
              nome: item.nome,
              descricao: item.descricao
            });
          });

          this.dataTable.data = model;

        },
        error: (e) => {
          console.log(e.error.response);
        }
      })
      .add(() => {
        this.spinnerService.hide();
      })
  }

  redirectToNew() {
    this._router.navigate(['portfolios/portfolios-create'])
  }

  redirectToEdit(id: number) {
    this._router.navigate(['portfolios/portfolios-edit/' + id])
  }

  redirectToDelete(id: number) {
    const request = new PortfoliosModel(
      0,
      0,
      '',
      '',
    );

    deletPortfolio(id)
    .subscribe({
      next: () => {
        // this.mensagem = `${id}`;
        // window.location.reload();
        this._router.navigate(['home/'])
      },
      error: (e) => {
        this.mensagem = `Erro: ${e.response.data}`;
        console.log(e.response.data);
      },
    })
    .add(() => {
      this.spinnerService.hide();
    });
  }

  redirectToHome() {
    this._router.navigate(['home/'])
  }
}
