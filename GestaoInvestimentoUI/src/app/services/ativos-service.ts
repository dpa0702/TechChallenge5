import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { createRequest } from './commons.service';
import { AtivoModel } from '../models/ativos.model';

//função para acessar o serviço de consulta de livros
export function getAtivo(): Observable<AtivoModel[]> {
    const config = {
        method: 'get',
        url: `${environment.apiGestaoInvestimentos}/Ativo`
    };

    return createRequest<AtivoModel[]>(config);
}

//função para consultar 1 ativo por id
export function getAtivoById(id: number): Observable<AtivoModel> {
    const config = {
        method: 'get',
        url: `${environment.apiGestaoInvestimentos}/Ativo/GetAtivoById/${id}`
    }

    return createRequest<AtivoModel>(config);
}

//função para cadastrar ativo
export function postAtivo(request: AtivoModel): Observable<AtivoModel> {
    const config = {
        method: 'post',
        url: `${environment.apiGestaoInvestimentos}/Ativo`,
        data: request
    }

    return createRequest<AtivoModel>(config);
}

export function putAtivo(request: AtivoModel): Observable<AtivoModel> {
    const config = {
        method: 'put',
        url: `${environment.apiGestaoInvestimentos}/Ativo`,
        data: request
    }

    return createRequest<AtivoModel>(config);
}
