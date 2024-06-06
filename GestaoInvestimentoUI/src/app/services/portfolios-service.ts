import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { createRequest } from './commons.service';
import { PortfoliosModel } from '../models/portfolios.model';

//função para acessar o serviço de consulta de livros
export function getPortfolio(): Observable<PortfoliosModel[]> {
    const config = {
        method: 'get',
        url: `${environment.apiGestaoInvestimentos}/Portfolio`
    };

    return createRequest<PortfoliosModel[]>(config);
}

//função para consultar 1 Portfolio por id
export function getPortfolioById(id: number): Observable<PortfoliosModel> {
    const config = {
        method: 'get',
        url: `${environment.apiGestaoInvestimentos}/Portfolio/GetPortfolioById/${id}`
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
        url: `${environment.apiGestaoInvestimentos}/Portfolio`,
        data: request
    }

    return createRequest<PortfoliosModel>(config);
}
