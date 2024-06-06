import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { AtivoModel } from 'src/app/models/ativos.model';
import { getAtivo } from 'src/app/services/ativos-service';

@Component({
  selector: 'app-ativos-list',
  templateUrl: './ativos-list.component.html',
  styleUrls: ['./ativos-list.component.css']
})
export class AtivosListComponent implements OnInit{

  //mome das colunas do grid (DataTable) no material
  colunas: string[] = ['id', 'tipoAtivo', 'nome', 'codigo'];
  
  //dados preenchidos na tabela
  dataTable = new MatTableDataSource<AtivoModel>();

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
}
