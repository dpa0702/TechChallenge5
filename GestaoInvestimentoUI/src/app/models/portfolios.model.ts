import { UsuarioModel } from "./usuarios.model";

export class PortfoliosModel {
    constructor(
      public id: number,
      public usuarioId: number,
      public nome: string,
      public descricao: string,
      public usuario: UsuarioModel,
    ) {}
  }