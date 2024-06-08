import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';
import { AtivoModel } from 'src/app/models/ativos.model';
import { getAtivo } from 'src/app/services/ativos-service';
import { deleteAtivo } from 'src/app/services/ativos-service';

@Component({
  selector: 'app-ativos-list',
  templateUrl: './ativos-list.component.html',
  styleUrls: ['./ativos-list.component.css']
})
export class AtivosListComponent implements OnInit {

  //mome das colunas do grid (DataTable) no material
  colunas: string[] = ['id', 'tipoAtivo', 'nome', 'codigo', 'actions'];

  //dados preenchidos na tabela
  dataTable = new MatTableDataSource<AtivoModel>();

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
      tipoAtivo: null,
      nome: [''],
      codigo: [''],
    })
  }

  ngOnInit() {
    this.spinnerService.show();

    const id = this.listForm.value.id as number;
    const tipoAtivo = this.listForm.value.tipoAtivo as number;
    const nome = this.listForm.value.nome as string;
    const codigo = this.listForm.value.codigo as string;

    getAtivo()
      .subscribe({
        next: (data) => {

          const model: AtivoModel[] = [];

          data.forEach(item => {
            model.push({
              id: item.id,
              tipoAtivo: item.tipoAtivo,
              nome: item.nome,
              codigo: item.codigo,
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
    const tipoAtivo = this.listForm.value.tipoAtivo as number;
    const nome = this.listForm.value.nome as string;
    const codigo = this.listForm.value.codigo as string;

    getAtivo()
      .subscribe({
        next: (data) => {

          const model: AtivoModel[] = [];

          data.forEach(item => {
            model.push({
              id: item.id,
              tipoAtivo: item.tipoAtivo,
              nome: item.nome,
              codigo: item.codigo,
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
    this._router.navigate(['ativos/ativos-create'])
  }
  redirectToEdit(id: number) {
    this._router.navigate(['ativos/ativos-edit/' + id])
  }
  redirectToDelete(id: number){
    alert(id);
    const request = new AtivoModel(
      0,
      0,
      '',
      '',
    );

    deleteAtivo(id)
    .subscribe({
      next: () => {
        this.mensagem = `${id}`;
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
}
