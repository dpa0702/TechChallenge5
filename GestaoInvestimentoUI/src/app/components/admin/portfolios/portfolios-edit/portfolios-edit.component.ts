import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { getPortfolioById } from 'src/app/services/portfolios-service';
import { putPortfolio } from 'src/app/services/portfolios-service';
import { PortfoliosModel } from 'src/app/models/portfolios.model';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { UsuarioModel } from 'src/app/models/usuarios.model';
import { getUsuario } from 'src/app/services/usuarios-service';

@Component({
  selector: 'app-portfolios-edit',
  templateUrl: './portfolios-edit.component.html',
  styleUrls: ['./portfolios-edit.component.css'],
})
export class PortfolioEditComponent implements OnInit {
  // public id: number = 0;
  createForm: FormGroup;
  mensagem: string = '';
  dataTable = new MatTableDataSource<PortfoliosModel>();
  usuarios = [
    { id: 1, nome: 'Nome', email: 'E-mail', senha: 'Senha' }
  ];

  constructor(
    private formBuilder: FormBuilder,
    private spinnerService: NgxSpinnerService,
    private route: ActivatedRoute,
    private _router: Router,
  ) {
    this.createForm = this.formBuilder.group({
      id: 0,
      usuarioId: ['', Validators.required],
      nome: ['', Validators.required],
      descricao: ['', Validators.required],
    });
  }

  get form(): any {
    return this.createForm.controls;
  }

  ngOnInit(): void {
    this.spinnerService.show();

    const id = this.route.snapshot.paramMap.get('id');

    const request = new UsuarioModel(
      0,
      '',
      '',
      '',
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
          this.usuarios = model;
        },
        error: (e) => {
          console.log(e.error.response);
        }
      })
      .add(() => {
        this.spinnerService.hide();
      });

    getPortfolioById(id)
      .subscribe((data) => {
        this.createForm.controls['id'].setValue(data.id);
        this.createForm.controls['usuarioId'].setValue(data.usuarioId);
        this.createForm.controls['nome'].setValue(data.nome);
        this.createForm.controls['descricao'].setValue(data.descricao);
      })
      .add(() => {
        this.spinnerService.hide();
      });
  }

  onSubmit(): void {
    this.spinnerService.show();

    //capturar os campos do formulário
    const request = new PortfoliosModel(
      this.createForm.value.id as number,
      this.createForm.value.usuarioId as number,
      this.createForm.value.nome as string,
      this.createForm.value.descricao as string,
      null as unknown as UsuarioModel,
    );

    //realizando a atualização
    putPortfolio(request)
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
          this._router.navigate(['portfolios/consulta-de-portfolios']);
        }
      })
      .add(() => {
        this.spinnerService.hide();
      });
  }
}
