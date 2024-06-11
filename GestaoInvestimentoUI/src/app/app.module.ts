import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxSpinnerModule } from 'ngx-spinner';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/layout/navbar/navbar.component';
import { RoutingModule } from './app.routing';
import { MaterialModule } from './app.material';
import { MessagesComponent } from './components/layout/messages/messages.component';
import { CommonModule, DatePipe } from '@angular/common';
import { HomeComponent } from './components/pages/home/home.component';
import { AtivosListComponent } from './components/admin/ativos/ativos-list/ativos-list.component';
import { PortfoliosListComponent } from './components/admin/portfolios/portfolios-list/portfolios-list.component';
import { TransacoesListComponent } from './components/admin/transacoes/transacoes-list/transacoes-list.component';
import { UsuariosListComponent } from './components/admin/usuarios/usuarios-list/usuarios-list.component';
import { AtivoCreateComponent } from './components/admin/ativos/ativos-create/ativos-create.component';
import { UsuariosCreateComponent } from './components/admin/usuarios/usuarios-create/usuarios-create.component';
import { AtivoEditComponent } from './components/admin/ativos/ativos-edit/ativos-edit.component';
import { UsuarioEditComponent } from './components/admin/usuarios/usuarios-edit/usuarios-edit.component';
import { PortfolioCreateComponent } from './components/admin/portfolios/portfolios-create/portfolios-create.component';
import { PortfolioEditComponent } from './components/admin/portfolios/portfolios-edit/portfolios-edit.component';
import { TransacaoCreateComponent } from './components/admin/transacoes/transacoes-create/transacoes-create.component';
import { TransacaoEditComponent } from './components/admin/transacoes/transacoes-edit/transacoes-edit.component';
import {MatCardModule} from '@angular/material/card';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatButtonModule} from '@angular/material/button';
import { HttpClientModule } from '@angular/common/http'
import { ToastrModule } from 'ngx-toastr';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,    
    MessagesComponent,
    AtivosListComponent,
    PortfoliosListComponent,
    TransacoesListComponent,
    UsuariosListComponent,
    AtivoCreateComponent,
    AtivoEditComponent,
    UsuariosCreateComponent,
    UsuarioEditComponent,
    PortfolioCreateComponent,
    PortfolioEditComponent,
    TransacaoCreateComponent,
    TransacaoEditComponent
  ],
  imports: [
    BrowserModule,
    RoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    NgxSpinnerModule,
    CommonModule,
    MatCardModule,
    MatInputModule,
    MatButtonModule,
    MatFormFieldModule,
    HttpClientModule,
    ToastrModule.forRoot({
      positionClass :'toast-top-right'
    })
  ],
  providers: [
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
