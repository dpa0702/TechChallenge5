import { AtivoModel } from "./ativos.model";
import { PortfoliosModel } from "./portfolios.model";

export class TransacaoModel {
    constructor(
      public id: number,
      public portfolioId: number,
      public ativoId: number,
      public tipoTransacao: number,
      public quantidade: number,
      public preco: number,
      public dataTransacao: string,
      public portfolio: PortfoliosModel,
      public ativo: AtivoModel,
    ) {}
  }
  