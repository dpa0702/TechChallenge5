import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { createRequest } from './commons.service';
import { PortfoliosModel } from '../models/portfolios.model';

//função para acessar o serviço de consulta de livros
export function getPortfolio(request: PortfoliosModel): Observable<PortfoliosModel[]> {
    let Url = new URL(`${environment.apiGestaoInvestimentos}/Portfolio`);
    if(request.id != null)
        Url.searchParams.set('id', request.id.toString());
    if(request.usuarioId != null)
        Url.searchParams.set('usuarioId', request.usuarioId.toString());
    if(request.nome != '')
        Url.searchParams.set('nome', request.nome);
    if(request.descricao != '')
        Url.searchParams.set('descricao', request.descricao);
    //   alert(Url);
    const config = {
        method: 'get',
        url: Url,//`${environment.apiGestaoInvestimentos}/Portfolio`
    };

    return createRequest<PortfoliosModel[]>(config);
}

//função para consultar 1 Portfolio por id
export function getPortfolioById(id: any): Observable<PortfoliosModel> {
    const config = {
        method: 'get',
        url: `${environment.apiGestaoInvestimentos}/Portfolio/${id}`
    }

    return createRequest<PortfoliosModel>(config);
}

//função para cadastrar Portfolio
export function postPortfolio(request: PortfoliosModel): Observable<PortfoliosModel> {
    const config = {
        method: 'post',
        url: `${environment.apiGestaoInvestimentos}/Portfolio`,
        data: request
    }

    return createRequest<PortfoliosModel>(config);
}

export function putPortfolio(request: PortfoliosModel): Observable<PortfoliosModel> {
    const config = {
        method: 'put',
        url: `${environment.apiGestaoInvestimentos}/Portfolio/`,
        data: request
    }

    return createRequest<PortfoliosModel>(config);
}

export function deletPortfolio(id: number): Observable<PortfoliosModel> {
    const config = {
        method: 'delete',
        url: `${environment.apiGestaoInvestimentos}/Portfolio/` + id,
        data: id
    }

    return createRequest<PortfoliosModel>(config);
}
