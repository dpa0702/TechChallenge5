﻿namespace GestaoInvestimentosCore.Enums
{
    public enum TipoAtivo
    {
        Acao = 1,
        Titulo = 2,
        Criptomoeda = 3,
    }

    public static class TipoAtivoDescription
    {
        public const string Acao = "Ação";
        public const string Titulo = "Título";
        public const string Criptomoeda = "Crypto";
    }
}
