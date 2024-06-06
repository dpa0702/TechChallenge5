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

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,    
    MessagesComponent,
    AtivosListComponent,
    PortfoliosListComponent,
    TransacoesListComponent,
    UsuariosListComponent
  ],
  imports: [
    BrowserModule,
    RoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    NgxSpinnerModule,
    CommonModule
  ],
  providers: [
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
