import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';
import { UsuarioModel } from 'src/app/models/usuarios.model';
import { deleteUsuario, getUsuario } from 'src/app/services/usuarios-service';

@Component({
  selector: 'app-usuarios-list',
  templateUrl: './usuarios-list.component.html',
  styleUrls: ['./usuarios-list.component.css']
})
export class UsuariosListComponent implements OnInit {

  //mome das colunas do grid (DataTable) no material
  colunas: string[] = ['id', 'nome', 'email', 'senha', 'actions'];

  //dados preenchidos na tabela
  dataTable = new MatTableDataSource<UsuarioModel>();

  //formulário
  listForm: FormGroup;

  //exibição de mensagem:
  mensagem: string = '';

  constructor(
    private formBuilder: FormBuilder,
    private spinnerService: NgxSpinnerService,
    private _router: Router,
  ) {
    this.listForm = this.formBuilder.group({
      id: null,
      nome: [''],
      email: [''],
      senha: ['']
    })
  }

  ngOnInit() {
    this.spinnerService.show();

    const request = new UsuarioModel(
      this.listForm.value.id,
      this.listForm.value.nome as string,
      this.listForm.value.email as string,
      this.listForm.value.senha as string,
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

  get form(): any {
    return this.listForm.controls;
  }

  onSubmit(): void {
    this.spinnerService.show();

    const request = new UsuarioModel(
      this.listForm.value.id,
      this.listForm.value.nome as string,
      this.listForm.value.email as string,
      this.listForm.value.senha as string,
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
    this._router.navigate(['usuarios/usuarios-create'])
  }

  redirectToEdit(id: number) {
    this._router.navigate(['usuarios/usuarios-edit/' + id])
  }

  redirectToDelete(id: number){
    const request = new UsuarioModel(
      0,
      '',
      '',
      '',
    );

    deleteUsuario(id)
    .subscribe({
      next: () => {
        // this.mensagem = `${id}`;
        window.location.reload()
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
