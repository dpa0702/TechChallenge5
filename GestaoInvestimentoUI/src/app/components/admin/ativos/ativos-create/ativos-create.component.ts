import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { postAtivo } from 'src/app/services/ativos-service';
import { AtivoModel } from 'src/app/models/ativos.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-ativos-create',
  templateUrl: './ativos-create.component.html',
  styleUrls: ['./ativos-create.component.css'],
})
export class AtivoCreateComponent implements OnInit {
  createForm: FormGroup;
  mensagem: string = '';

  constructor(
    private formBuilder: FormBuilder,
    private spinnerService: NgxSpinnerService,
    private _router: Router,
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
    postAtivo(request)
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
          this._router.navigate(['ativos/consulta-de-ativos']);
        }
      })
      .add(() => {
        this.spinnerService.hide();
      });
  }
}
