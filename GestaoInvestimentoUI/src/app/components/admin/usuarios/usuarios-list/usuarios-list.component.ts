import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { UsuarioModel } from 'src/app/models/usuarios.model';
import { getUsuario } from 'src/app/services/usuarios-service';

@Component({
  selector: 'app-usuarios-list',
  templateUrl: './usuarios-list.component.html',
  styleUrls: ['./usuarios-list.component.css']
})
export class UsuariosListComponent implements OnInit{

  //mome das colunas do grid (DataTable) no material
  colunas: string[] = ['id', 'nome', 'email', 'senha'];
  
  //dados preenchidos na tabela
  dataTable = new MatTableDataSource<UsuarioModel>();

  //formulário
  listForm: FormGroup;

  //exibição de mensagem:
  mensagem: string = '';

  constructor(
    private formBuilder: FormBuilder,
    private spinnerService: NgxSpinnerService
  ){
    this.listForm = this.formBuilder.group({
      id: null,
      nome: [''],
      email: [''],
      senha: ['']
    })
  }

  ngOnInit() {
    this.spinnerService.show();

    const id = this.listForm.value.id as number;

    getUsuario()
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

    const id = this.listForm.value.id as number;

    getUsuario()
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
}
