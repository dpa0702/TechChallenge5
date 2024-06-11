import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { createRequest } from './commons.service';
import { TransacaoModel } from '../models/transacoes.model';

//função para acessar o serviço de consulta de livros
export function getTransacao(request: TransacaoModel): Observable<TransacaoModel[]> {
    let Url = new URL(`${environment.apiGestaoInvestimentos}/Transacao`);
    if(request.id != null)
        Url.searchParams.set('id', request.id.toString());
    if(request.portfolioId != null)
        Url.searchParams.set('portfolioId', request.portfolioId.toString());
    if(request.ativoId != null)
        Url.searchParams.set('ativoId', request.ativoId.toString());
    if(request.tipoTransacao != null)
        Url.searchParams.set('tipoTransacao', request.tipoTransacao.toString());
    if(request.quantidade != null)
        Url.searchParams.set('quantidade', request.quantidade.toString());
    if(request.preco != null)
        Url.searchParams.set('preco', request.preco.toString());
    if(request.dataTransacao != '')
        Url.searchParams.set('dataTransacao', request.dataTransacao);
    //  alert(Url);
    const config = {
        method: 'get',
        url: Url,//`${environment.apiGestaoInvestimentos}/Transacao`
    };

    return createRequest<TransacaoModel[]>(config);
}

//função para consultar 1 Transacao por id
export function getTransacaoById(id: any): Observable<TransacaoModel> {
    const config = {
        method: 'get',
        url: `${environment.apiGestaoInvestimentos}/Transacao/${id}`
    }

    return createRequest<TransacaoModel>(config);
}

//função para cadastrar Transacao
export function postTransacao(request: TransacaoModel): Observable<TransacaoModel> {
    const config = {
        method: 'post',
        url: `${environment.apiGestaoInvestimentos}/Transacao`,
        data: request
    }

    return createRequest<TransacaoModel>(config);
}

export function putTransacao(request: TransacaoModel): Observable<TransacaoModel> {
    const config = {
        method: 'put',
        url: `${environment.apiGestaoInvestimentos}/Transacao/`,
        data: request
    }

    return createRequest<TransacaoModel>(config);
}

export function deleteTransacao(id: number): Observable<TransacaoModel> {
    const config = {
        method: 'delete',
        url: `${environment.apiGestaoInvestimentos}/Transacao/` + id,
        data: id
    }

    return createRequest<TransacaoModel>(config);
}