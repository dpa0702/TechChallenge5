import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { getUsuarioById } from 'src/app/services/usuarios-service';
import { putUsuario } from 'src/app/services/usuarios-service';
import { UsuarioModel } from 'src/app/models/usuarios.model';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-usuarios-edit',
  templateUrl: './usuarios-edit.component.html',
  styleUrls: ['./usuarios-edit.component.css'],
})
export class UsuarioEditComponent implements OnInit {
  // public id: number = 0;
  createForm: FormGroup;
  mensagem: string = '';
  dataTable = new MatTableDataSource<UsuarioModel>();

  constructor(
    private formBuilder: FormBuilder,
    private spinnerService: NgxSpinnerService,
    private route: ActivatedRoute,
    private _router: Router,
  ) {
    this.createForm = this.formBuilder.group({
      id: 0,
      nome: ['', Validators.required],
      email: ['', Validators.required],
      senha: ['', Validators.required],
    });
  }

  get form(): any {
    return this.createForm.controls;
  }

  ngOnInit(): void {
    this.spinnerService.show();

    const id = this.route.snapshot.paramMap.get('id');

    getUsuarioById(id)
      .subscribe((data) => {
        this.createForm.controls['id'].setValue(data.id);
        this.createForm.controls['nome'].setValue(data.nome);
        this.createForm.controls['email'].setValue(data.email);
        this.createForm.controls['senha'].setValue(data.senha);
      })
      .add(() => {
        this.spinnerService.hide();
      });

  }

  onSubmit(): void {
    this.spinnerService.show();

    //capturar os campos do formulário
    const request = new UsuarioModel(
      this.createForm.value.id as number,
      this.createForm.value.nome as string,
      this.createForm.value.email as string,
      this.createForm.value.senha as string,
    );

    //realizando a atualização
    putUsuario(request)
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
          this._router.navigate(['usuarios/consulta-de-usuarios']);
        }
      })
      .add(() => {
        this.spinnerService.hide();
      });
  }
}
