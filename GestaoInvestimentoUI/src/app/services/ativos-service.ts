import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { createRequest } from './commons.service';
import { AtivoModel } from '../models/ativos.model';

//função para acessar o serviço de consulta de livros
export function getAtivo(request: AtivoModel): Observable<AtivoModel[]> {

    let Url = new URL(`${environment.apiGestaoInvestimentos}/Ativo`);
    if(request.id != null)
        Url.searchParams.set('id', request.id.toString());
    if(request.tipoAtivo != null)
        Url.searchParams.set('tipoAtivo', request.tipoAtivo.toString());
    if(request.nome != '')
        Url.searchParams.set('nome', request.nome);
    if(request.codigo != '')
        Url.searchParams.set('codigo', request.codigo);


    const config = {
        method: 'get',
        url: Url,//`${environment.apiGestaoInvestimentos}/Ativo?id=${request.id}&tipoAtivo=${request.tipoAtivo}&nome=${request.nome}&codigo=${request.codigo}`,
    };

    return createRequest<AtivoModel[]>(config);
}

//função para consultar 1 ativo por id
export function getAtivoById(id: any): Observable<AtivoModel> {
    const config = {
        method: 'get',
        url: `${environment.apiGestaoInvestimentos}/Ativo/${id}`
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
        url: `${environment.apiGestaoInvestimentos}/Ativo/`,
        data: request
    }

    return createRequest<AtivoModel>(config);
}

export function deleteAtivo(id: number): Observable<AtivoModel> {
    const config = {
        method: 'delete',
        url: `${environment.apiGestaoInvestimentos}/Ativo/` + id,
        data: id
    }

    return createRequest<AtivoModel>(config);
}