import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { createRequest } from './commons.service';
import { TransacaoModel } from '../models/transacoes.model';

//função para acessar o serviço de consulta de livros
export function getTransacao(): Observable<TransacaoModel[]> {
    const config = {
        method: 'get',
        url: `${environment.apiGestaoInvestimentos}/Transacao`
    };

    return createRequest<TransacaoModel[]>(config);
}

//função para consultar 1 Transacao por id
export function getTransacaoById(id: number): Observable<TransacaoModel> {
    const config = {
        method: 'get',
        url: `${environment.apiGestaoInvestimentos}/Transacao/GetTransacaoById/${id}`
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
        url: `${environment.apiGestaoInvestimentos}/Transacao`,
        data: request
    }

    return createRequest<TransacaoModel>(config);
}
