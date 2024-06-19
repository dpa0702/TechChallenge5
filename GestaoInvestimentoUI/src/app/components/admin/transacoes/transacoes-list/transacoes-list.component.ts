import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';
import { TransacaoModel } from 'src/app/models/transacoes.model';
import { deleteTransacao, getTransacao } from 'src/app/services/transacoes-services';
import { AtivoModel } from 'src/app/models/ativos.model';
import { getAtivo } from 'src/app/services/ativos-service';
import { PortfoliosModel } from 'src/app/models/portfolios.model';
import { getPortfolio } from 'src/app/services/portfolios-service';
import { UsuarioModel } from 'src/app/models/usuarios.model';

@Component({
  selector: 'app-transacoes-list',
  templateUrl: './transacoes-list.component.html',
  styleUrls: ['./transacoes-list.component.css']
})
export class TransacoesListComponent implements OnInit {

  //mome das colunas do grid (DataTable) no material
  colunas: string[] = ['id', 'portfolio.nome', 'ativo.nome', 'tipoTransacao', 'quantidade', 'preco', 'dataTransacao', 'actions'];

  //dados preenchidos na tabela
  dataTable = new MatTableDataSource<TransacaoModel>();

  //formulário
  listForm: FormGroup;

  //exibição de mensagem:
  mensagem: string = '';

  portfolios = [
    { id: 0, usuarioId: 0, nome: 'Escolha uma opção', descricao: 'descricao' }
  ];

  ativos = [
    { id: 0, tipoAtivo: 0, nome: 'Escolha uma opção', codigo: 'Código' }
  ];

  constructor(
    private formBuilder: FormBuilder,
    private spinnerService: NgxSpinnerService,
    private _router: Router,
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

    const requestP = new PortfoliosModel(
      0,
      0,
      '',
      '',
      null as unknown as UsuarioModel,
    );

    getPortfolio(requestP)
      .subscribe({
        next: (dataP) => {
          dataP.forEach(item => {
            this.portfolios.push({
              id: item.id,
              usuarioId: item.usuarioId,
              nome: item.nome,
              descricao: item.descricao,
            });
          });
        },
        error: (e) => {
          console.log(e.error.response);
        }
      })
      .add(() => {
        this.spinnerService.hide();
      });


    const requestT = new TransacaoModel(
      this.listForm.value.id,
      this.listForm.value.portfolioId as number,
      this.listForm.value.ativoId as number,
      this.listForm.value.tipoTransacao as number,
      this.listForm.value.quantidade as number,
      this.listForm.value.preco as number,
      this.listForm.value.dataTransacao as string,
      null as unknown as PortfoliosModel,
      null as unknown as AtivoModel,
    );

    getTransacao(requestT)
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
              portfolio: item.portfolio,
              ativo: item.ativo,
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

    const requestA = new AtivoModel(
      0,
      0,
      '',
      '',
    );

    getAtivo(requestA)
      .subscribe({
        next: (dataA) => {
          dataA.forEach(item => {
            this.ativos.push({
              id: item.id,
              tipoAtivo: item.tipoAtivo,
              nome: item.nome,
              codigo: item.codigo,
            });
          });
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

    const requestTN = new TransacaoModel(
      this.listForm.value.id,
      this.listForm.value.portfolioId as number,
      this.listForm.value.ativoId as number,
      this.listForm.value.tipoTransacao as number,
      this.listForm.value.quantidade as number,
      this.listForm.value.preco as number,
      this.listForm.value.dataTransacao as string,
      null as unknown as PortfoliosModel,
      null as unknown as AtivoModel,
    );

    getTransacao(requestTN)
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
              portfolio: item.portfolio,
              ativo: item.ativo,
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
    this._router.navigate(['transacoes/transacoes-create'])
  }

  redirectToEdit(id: number) {
    this._router.navigate(['transacoes/transacoes-edit/' + id])
  }

  redirectToDelete(id: number) {
    const request = new TransacaoModel(
      0,
      0,
      0,
      0,
      0,
      0,
      '',
      null as unknown as PortfoliosModel,
      null as unknown as AtivoModel,
    );

    deleteTransacao(id)
      .subscribe({
        next: () => {
          // this.mensagem = `${id}`;
          // window.location.reload();
          this._router.navigate(['home/']);
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
