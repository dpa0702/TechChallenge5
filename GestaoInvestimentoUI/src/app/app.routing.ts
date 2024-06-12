import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
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
import { guardaGuard } from './components/auth/guard/guarda.guard';

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
    canActivate: [guardaGuard]
  },
  {
    path: 'portfolios/consulta-de-portfolios',
    component: PortfoliosListComponent,
    canActivate: [guardaGuard]
  },
  {
    path: 'transacoes/consulta-de-transacoes',
    component: TransacoesListComponent,
    canActivate: [guardaGuard]
  },
  {
    path: 'usuarios/consulta-de-usuarios',
    component: UsuariosListComponent,
    canActivate: [guardaGuard]
  },
  {
    path: 'ativos/ativos-create',
    component: AtivoCreateComponent,
    canActivate: [guardaGuard]
  },
  {
    path: 'ativos/ativos-edit/:id',
    component: AtivoEditComponent,
    canActivate: [guardaGuard]
  },
  {
    path: 'usuarios/usuarios-create',
    component: UsuariosCreateComponent,
    canActivate: [guardaGuard]
  },
  {
    path: 'usuarios/usuarios-edit/:id',
    component: UsuarioEditComponent,
    canActivate: [guardaGuard]
  },
  {
    path: 'portfolios/portfolios-create',
    component: PortfolioCreateComponent,
    canActivate: [guardaGuard]
  },
  {
    path: 'portfolios/portfolios-edit/:id',
    component: PortfolioEditComponent,
    canActivate: [guardaGuard]
  },
  {
    path: 'transacoes/transacoes-create',
    component: TransacaoCreateComponent,
    canActivate: [guardaGuard]
  },
  {
    path: 'transacoes/transacoes-edit/:id',
    component: TransacaoEditComponent,
    canActivate: [guardaGuard]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class RoutingModule {}
