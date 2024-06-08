import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { getAtivo } from 'src/app/services/ativos-service';
import { putAtivo } from 'src/app/services/ativos-service';
import { AtivoModel } from 'src/app/models/ativos.model';

@Component({
  selector: 'app-ativos-edit',
  templateUrl: './ativos-edit.component.html',
  styleUrls: ['./ativos-edit.component.css'],
})
export class AtivoEditComponent implements OnInit {
  createForm: FormGroup;
  mensagem: string = '';
  dataTable = new MatTableDataSource<AtivoModel>();

  constructor(
    private formBuilder: FormBuilder,
    private spinnerService: NgxSpinnerService
  ) {
    this.createForm = this.formBuilder.group({
        tipoAtivo: ['', Validators.required],
        nome: ['', Validators.required],
        codigo: ['', Validators.required],
    });
  }

  get form(): any {
    return this.createForm.controls;
  }

  ngOnInit(): void {
    this.spinnerService.show();

    const id = this.createForm.value.id as number;
    const tipoAtivo = this.createForm.value.tipoAtivo as number;
    const nome = this.createForm.value.nome as string;
    const codigo = this.createForm.value.codigo as string;

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

  onSubmit(): void {
    this.spinnerService.show();

    //capturar os campos do formulário
    const request = new AtivoModel(
      0,
      this.createForm.value.tipoAtivo as number,
      this.createForm.value.nome as string,
      this.createForm.value.codigo as string,
    );

    //realizando o cadastro
    putAtivo(request)
      .subscribe({
        next: (data) => {
          this.mensagem = `${data}`;
          this.createForm.reset();
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
