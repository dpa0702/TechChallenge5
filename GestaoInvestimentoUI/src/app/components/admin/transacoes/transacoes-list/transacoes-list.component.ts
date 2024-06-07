import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { TransacaoModel } from 'src/app/models/transacoes.model';
import { getTransacao } from 'src/app/services/transacoes-services';

@Component({
  selector: 'app-transacoes-list',
  templateUrl: './transacoes-list.component.html',
  styleUrls: ['./transacoes-list.component.css']
})
export class TransacoesListComponent implements OnInit {

  //mome das colunas do grid (DataTable) no material
  colunas: string[] = ['id', 'portfolioId', 'ativoId', 'tipoTransacao', 'quantidade', 'preco', 'dataTransacao', 'actions'];

  //dados preenchidos na tabela
  dataTable = new MatTableDataSource<TransacaoModel>();

  //formulário
  listForm: FormGroup;

  //exibição de mensagem:
  mensagem: string = '';

  constructor(
    private formBuilder: FormBuilder,
    private spinnerService: NgxSpinnerService
  ) {
    this.listForm = this.formBuilder.group({
      id: null,
      portfolioId: null,
      ativoId: null,
      tipoTransacao: null,
      quantidade: null,
      preco: null,
      dataTransacao: [''],
    })
  }

  ngOnInit() {
    this.spinnerService.show();

    const id = this.listForm.value.id as number;

    getTransacao()
      .subscribe({
        next: (data) => {

          const model: TransacaoModel[] = [];

          data.forEach(item => {
            model.push({
              id: item.id,
              portfolioId: item.portfolioId,
              ativoId: item.ativoId,
              tipoTransacao: item.tipoTransacao,
              quantidade: item.quantidade,
              preco: item.preco,
              dataTransacao: item.dataTransacao,
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

    getTransacao()
      .subscribe({
        next: (data) => {

          const model: TransacaoModel[] = [];

          data.forEach(item => {
            model.push({
              id: item.id,
              portfolioId: item.portfolioId,
              ativoId: item.ativoId,
              tipoTransacao: item.tipoTransacao,
              quantidade: item.quantidade,
              preco: item.preco,
              dataTransacao: item.dataTransacao,
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
