import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { getAtivoById } from 'src/app/services/ativos-service';
import { putAtivo } from 'src/app/services/ativos-service';
import { AtivoModel } from 'src/app/models/ativos.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-ativos-edit',
  templateUrl: './ativos-edit.component.html',
  styleUrls: ['./ativos-edit.component.css'],
})
export class AtivoEditComponent implements OnInit {
  // public id: number = 0;
  createForm: FormGroup;
  mensagem: string = '';
  dataTable = new MatTableDataSource<AtivoModel>();

  constructor(
    private formBuilder: FormBuilder,
    private spinnerService: NgxSpinnerService,
    private route: ActivatedRoute,
  ) {
    this.createForm = this.formBuilder.group({
      id: 0,
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

    const id = this.route.snapshot.paramMap.get('id');

    getAtivoById(id)
      .subscribe((data) => {
        this.createForm.controls['id'].setValue(data.id);
        this.createForm.controls['tipoAtivo'].setValue(data.tipoAtivo);
        this.createForm.controls['nome'].setValue(data.nome);
        this.createForm.controls['codigo'].setValue(data.codigo);
      })
      .add(() => {
        this.spinnerService.hide();
      });

  }

  onSubmit(): void {
    this.spinnerService.show();

    //capturar os campos do formulário
    const request = new AtivoModel(
      this.createForm.value.id as number,
      this.createForm.value.tipoAtivo as number,
      this.createForm.value.nome as string,
      this.createForm.value.codigo as string,
    );

    //realizando a atualização
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
