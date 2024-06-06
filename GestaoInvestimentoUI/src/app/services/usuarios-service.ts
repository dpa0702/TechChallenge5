import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { createRequest } from './commons.service';
import { UsuarioModel } from '../models/usuarios.model';

//função para acessar o serviço de consulta de livros
export function getUsuario(): Observable<UsuarioModel[]> {
    const config = {
        method: 'get',
        url: `${environment.apiGestaoInvestimentos}/usuario`
    };

    return createRequest<UsuarioModel[]>(config);
}

//função para consultar 1 usuario por id
export function getusuarioById(id: number): Observable<UsuarioModel> {
    const config = {
        method: 'get',
        url: `${environment.apiGestaoInvestimentos}/usuario/GetusuarioById/${id}`
    }

    return createRequest<UsuarioModel>(config);
}

//função para cadastrar usuario
export function postusuario(request: UsuarioModel): Observable<UsuarioModel> {
    const config = {
        method: 'post',
        url: `${environment.apiGestaoInvestimentos}/usuario`,
        data: request
    }

    return createRequest<UsuarioModel>(config);
}

export function putusuario(request: UsuarioModel): Observable<UsuarioModel> {
    const config = {
        method: 'put',
        url: `${environment.apiGestaoInvestimentos}/usuario`,
        data: request
    }

    return createRequest<UsuarioModel>(config);
}
