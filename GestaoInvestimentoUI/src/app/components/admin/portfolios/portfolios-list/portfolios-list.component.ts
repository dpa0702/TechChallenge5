import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';
import { PortfoliosModel } from 'src/app/models/portfolios.model';
import { getPortfolio } from 'src/app/services/portfolios-service';

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

  redirectToNew() {
    this._router.navigate(['portfolios/portfolios-create'])
  }

  redirectToEdit(id: number) {
    this._router.navigate(['portfolios/portfolios-edit/' + id])
  }

  redirectToDelete(id: number){
    const request = new PortfoliosModel(
      0,
      0,
      '',
      '',
    );

    // deleteAtivo(id)
    // .subscribe({
    //   next: () => {
    //     // this.mensagem = `${id}`;
    //     window.location.reload()
    //   },
    //   error: (e) => {
    //     this.mensagem = `Erro: ${e.response.data}`;
    //     console.log(e.response.data);
    //   },
    // })
    // .add(() => {
    //   this.spinnerService.hide();
    // });
  }

  redirectToHome() {
    this._router.navigate(['home/'])
  }
}
