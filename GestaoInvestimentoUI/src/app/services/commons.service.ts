import axios, { AxiosResponse } from "axios";
import { Observable } from "rxjs";

/*
    Função genérica <T> para realizar requisições
    HTTP para serviços de API (POST, PUT, DELETE, GET)
*/
export function createRequest<T>(config: any): Observable<T> {
    return new Observable<T>(observer => {
        axios(config)
            .then(response => handlerResponse(observer, response))
            .catch(error => handleError(observer, error));
    })
}

/*
    Função genérica para capturar a resposta de sucesso
    das requisições feitas para uma API
*/
function handlerResponse<T>(observer: any, response: AxiosResponse<T>) {
    observer.next(response.data);
    observer.complete();
}

/*
    Função genérica para capturar a resposta de erro
    das requisições feitas para uma API
*/
function handleError(observer: any, error: any) {
    observer.error(error);
}
