import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { createRequest } from './commons.service';
import { UsuarioModel } from '../models/usuarios.model';

//função para acessar o serviço de consulta de livros
export function getUsuario(request: UsuarioModel): Observable<UsuarioModel[]> {
    let Url = new URL(`${environment.apiGestaoInvestimentos}/usuario`);
    if(request.id != null)
        Url.searchParams.set('id', request.id.toString());
    if(request.nome != '')
        Url.searchParams.set('nome', request.nome);
    if(request.email != '')
        Url.searchParams.set('email', request.email);
    if(request.senha != '')
        Url.searchParams.set('senha', request.senha);
    // alert(Url);
    const config = {
        method: 'get',
        url: Url,//`${environment.apiGestaoInvestimentos}/usuario`
    };

    return createRequest<UsuarioModel[]>(config);
}

//função para consultar 1 usuario por id
export function getUsuarioById(id: any): Observable<UsuarioModel> {
    const config = {
        method: 'get',
        url: `${environment.apiGestaoInvestimentos}/usuario/${id}`
    }

    return createRequest<UsuarioModel>(config);
}

//função para cadastrar usuario
export function postUsuario(request: UsuarioModel): Observable<UsuarioModel> {
    const config = {
        method: 'post',
        url: `${environment.apiGestaoInvestimentos}/usuario`,
        data: request
    }

    return createRequest<UsuarioModel>(config);
}

export function putUsuario(request: UsuarioModel): Observable<UsuarioModel> {
    const config = {
        method: 'put',
        url: `${environment.apiGestaoInvestimentos}/usuario/`,
        data: request
    }

    return createRequest<UsuarioModel>(config);
}

export function deleteUsuario(id: number): Observable<UsuarioModel> {
    const config = {
        method: 'delete',
        url: `${environment.apiGestaoInvestimentos}/usuario/` + id,
        data: id
    }

    return createRequest<UsuarioModel>(config);
}