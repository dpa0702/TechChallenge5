import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { putTransacao, getTransacaoById } from 'src/app/services/transacoes-services';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { TransacaoModel } from 'src/app/models/transacoes.model';
import { PortfoliosModel } from 'src/app/models/portfolios.model';
import { getPortfolio } from 'src/app/services/portfolios-service';
import { AtivoModel } from 'src/app/models/ativos.model';
import { getAtivo } from 'src/app/services/ativos-service';
import { UsuarioModel } from 'src/app/models/usuarios.model';

@Component({
  selector: 'app-transacoes-edit',
  templateUrl: './transacoes-edit.component.html',
  styleUrls: ['./transacoes-edit.component.css'],
})
export class TransacaoEditComponent implements OnInit {
  // public id: number = 0;
  createForm: FormGroup;
  mensagem: string = '';
  dataTable = new MatTableDataSource<TransacaoModel>();
  usuarios = [
    { id: 1, nome: 'Nome', email: 'E-mail', senha: 'Senha' }
  ];
  portfolios = [
    { id: 1, usuarioId: 1, nome: 'nome', descricao: 'descricao' }
  ];
  ativos = [
    { id: 1, tipoAtivo: 1, nome: 'nome', codigo: 'codigo' }
  ];
  constructor(
    private formBuilder: FormBuilder,
    private spinnerService: NgxSpinnerService,
    private route: ActivatedRoute,
    private _router: Router,
  ) {
    this.createForm = this.formBuilder.group({
      id: 0,
      portfolioId: 0,
      ativoId: 0,
      tipoTransacao: 0,
      quantidade: 0,
      preco: 0,
      dataTransacao: '',
    });
  }

  get form(): any {
    return this.createForm.controls;
  }

  ngOnInit(): void {
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

      const id = this.route.snapshot.paramMap.get('id');

    getTransacaoById(id)
      .subscribe((data) => {
        this.createForm.controls['id'].setValue(data.id);
        this.createForm.controls['portfolioId'].setValue(data.portfolioId);
        this.createForm.controls['ativoId'].setValue(data.ativoId);
        this.createForm.controls['tipoTransacao'].setValue(data.tipoTransacao);
        this.createForm.controls['quantidade'].setValue(data.quantidade);
        this.createForm.controls['preco'].setValue(data.preco);
        this.createForm.controls['dataTransacao'].setValue(data.dataTransacao);
      })
      .add(() => {
        this.spinnerService.hide();
      });

    const request = new TransacaoModel(
      this.createForm.value.id as number,
      this.createForm.value.portfolioId as number,
      this.createForm.value.ativoId as number,
      this.createForm.value.tipoTransacao as number,
      this.createForm.value.quantidade as number,
      this.createForm.value.preco as number,
      this.createForm.value.dataTransacao as string,
      null as unknown as PortfoliosModel,
      null as unknown as AtivoModel,
    );

  }

  onSubmit(): void {
    this.spinnerService.show();

    //capturar os campos do formulário
    const request = new TransacaoModel(
      this.createForm.value.id as number,
      this.createForm.value.portfolioId as number,
      this.createForm.value.ativoId as number,
      this.createForm.value.tipoTransacao as number,
      this.createForm.value.quantidade as number,
      this.createForm.value.preco as number,
      this.createForm.value.dataTransacao as string,
      null as unknown as PortfoliosModel,
      null as unknown as AtivoModel,
    );
    // alert(request.dataTransacao);
    //realizando a atualização
    putTransacao(request)
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
