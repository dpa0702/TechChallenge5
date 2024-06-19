import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { postTransacao } from 'src/app/services/transacoes-services';
import { TransacaoModel } from 'src/app/models/transacoes.model';
import { Router } from '@angular/router';
import { PortfoliosModel } from 'src/app/models/portfolios.model';
import { getPortfolio } from 'src/app/services/portfolios-service';
import { AtivoModel } from 'src/app/models/ativos.model';
import { getAtivo } from 'src/app/services/ativos-service';
import { UsuarioModel } from 'src/app/models/usuarios.model';

@Component({
  selector: 'app-transacoes-create',
  templateUrl: './transacoes-create.component.html',
  styleUrls: ['./transacoes-create.component.css'],
})
export class TransacaoCreateComponent implements OnInit {
  createForm: FormGroup;
  mensagem: string = '';
  portfolios = [
    { id: 1, usuarioId: 1, nome: 'nome', descricao: 'descricao' }
  ];
  ativos = [
    { id: 1, tipoAtivo: 1, nome: 'nome', codigo: 'codigo' }
  ];

  constructor(
    private formBuilder: FormBuilder,
    private spinnerService: NgxSpinnerService,
    private _router: Router,
  ) {
    this.createForm = this.formBuilder.group({
      PortfolioId: ['', Validators.required],
      AtivoId: ['', Validators.required],
      TipoTransacao: ['', Validators.required],
      Quantidade: ['', Validators.required],
      Preco: ['', Validators.required],
    });
  }

  get form(): any {
    return this.createForm.controls;
  }

  ngOnInit(): void {
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

          const modelP: PortfoliosModel[] = [];

          dataP.forEach(item => {
            modelP.push({
              id: item.id,
              usuarioId: item.usuarioId,
              nome: item.nome,
              descricao: item.descricao,
              usuario: item.usuario,
            });
          });
          this.portfolios = modelP;
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

          const modelA: AtivoModel[] = [];

          dataA.forEach(item => {
            modelA.push({
              id: item.id,
              tipoAtivo: item.tipoAtivo,
              nome: item.nome,
              codigo: item.codigo,
            });
          });
          this.ativos = modelA;
        },
        error: (e) => {
          console.log(e.error.response);
        }
      })
      .add(() => {
        this.spinnerService.hide();
      });
  }

  onSubmit(): void {
    this.spinnerService.show();

    //capturar os campos do formulário
    const request = new TransacaoModel(
      0,
      this.createForm.value.PortfolioId as number,
      this.createForm.value.AtivoId as number,
      this.createForm.value.TipoTransacao as number,
      this.createForm.value.Quantidade as number,
      this.createForm.value.Preco as number,
      this.createForm.value.DataTransacao as string,
      null as unknown as PortfoliosModel,
      null as unknown as AtivoModel,
    );

    //realizando o cadastro
    postTransacao(request)
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
          this._router.navigate(['transacoes/consulta-de-transacoes']);
        }
      })
      .add(() => {
        this.spinnerService.hide();
      });
  }
}
