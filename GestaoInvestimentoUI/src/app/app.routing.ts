import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { HomeComponent } from './components/pages/home/home.component';
import { AtivosListComponent } from './components/admin/ativos/ativos-list/ativos-list.component';
import { PortfoliosListComponent } from './components/admin/portfolios/portfolios-list/portfolios-list.component';
import { TransacoesListComponent } from './components/admin/transacoes/transacoes-list/transacoes-list.component';
import { UsuariosListComponent } from './components/admin/usuarios/usuarios-list/usuarios-list.component';

const routes: Routes = [
  {
    path : '',
    loadChildren : () => import('./components/auth/auth.module').then(m => m.AuthModule),
  },
  {
    path: 'home',
    component: HomeComponent,
  },
  {
    path: 'ativos/consulta-de-ativos',
    component: AtivosListComponent,
  },
  {
    path: 'portfolios/consulta-de-portfolios',
    component: PortfoliosListComponent,
  },
  {
    path: 'transacoes/consulta-de-transacoes',
    component: TransacoesListComponent,
  },
  {
    path: 'usuarios/consulta-de-usuarios',
    component: UsuariosListComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class RoutingModule {}
