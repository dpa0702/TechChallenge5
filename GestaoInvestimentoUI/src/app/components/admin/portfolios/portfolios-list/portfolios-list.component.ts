import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { PortfoliosModel } from 'src/app/models/portfolios.model';
import { getPortfolio } from 'src/app/services/portfolios-service';

@Component({
  selector: 'app-portfolios-list',
  templateUrl: './portfolios-list.component.html',
  styleUrls: ['./portfolios-list.component.css']
})
export class PortfoliosListComponent implements OnInit{

  //mome das colunas do grid (DataTable) no material
  colunas: string[] = ['id', 'usuarioId', 'nome', 'descricao'];
  
  //dados preenchidos na tabela
  dataTable = new MatTableDataSource<PortfoliosModel>();

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
      usuarioId: null,
      nome: [''],
      descricao: [''],
    })
  }

  ngOnInit() {
    this.spinnerService.show();

    const id = this.listForm.value.id as number;

    getPortfolio()
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

  get form(): any {
    return this.listForm.controls;
  }

  onSubmit(): void {
    this.spinnerService.show();

    const id = this.listForm.value.id as number;

    getPortfolio()
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
}
